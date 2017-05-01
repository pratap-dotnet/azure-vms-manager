using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Fluent;

namespace AzureVMManager.Models
{
    public class AzureVirtualMachines
    {
        public class VMSize
        {
            public int MemoryInMB { get; set; }
            public int OSDiskSizeInMB { get; set; }
            public int NumberOfCores { get; set; }
            public int MaxDataDiskCount { get; set; }
        }

        private AzureVirtualMachines(IVirtualMachine vm, IAzure azure)
        {
            Name = vm.Name;
            AdminUser = vm.OSProfile?.AdminUsername;
            ResourceGroupName = vm.ResourceGroupName;
            ResourceId = vm.Id;
            State = vm.PowerState?.Value;
            OsType = vm.StorageProfile?.ImageReference?.Sku;

            var availableSizes = vm.AvailableSizes();
            var size = availableSizes.FirstOrDefault(a => a.Name == vm.Size.Value);

            Size = size == null ? null : new VMSize
            {
                MemoryInMB = size.MemoryInMB,
                MaxDataDiskCount = size.MaxDataDiskCount,
                NumberOfCores = size.NumberOfCores,
                OSDiskSizeInMB = size.OSDiskSizeInMB
            };
        }

        public string Name { get; set; }
        public string ResourceGroupName { get; set; }
        public string ResourceId { get; set; }
        public string State { get; set; }
        public string AdminUser { get; set; }
        public VMSize Size { get; set; }
        public string OsType { get; set; }

        public static async Task<IEnumerable<AzureVirtualMachines>> GetAllVMsAsync(AzureSettings azureSettings)
        {
            var azure = Azure
                .Configure()
                .Authenticate(azureSettings.GetAzureCredentials())
                .WithSubscription(azureSettings.SubscriptionId);

            var listOfVms = await azure.VirtualMachines.ListAsync();

            return listOfVms.Select(a => new AzureVirtualMachines(a,azure)).ToList();
        }
        
    }
}
