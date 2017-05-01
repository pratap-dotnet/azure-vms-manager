using System.Threading.Tasks;
using AzureVMManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AzureVMManager.Controllers
{
    [Produces("application/json")]
    [Route("api/vms")]
    public class VirtualMachinesController : Controller
    {
        private readonly AzureSettings azureSettings;
        public VirtualMachinesController(IOptions<AzureSettings> azureSettings)
        {
            this.azureSettings = azureSettings.Value;
        }

        public async Task<IActionResult> Get()
        {
            return Json(await AzureVirtualMachines.GetAllVMsAsync(azureSettings));
        }
    }
}