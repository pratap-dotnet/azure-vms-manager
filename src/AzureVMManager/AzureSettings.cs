using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;

namespace AzureVMManager
{
    public class AzureSettings
    {
        public string SubscriptionId { get; set; }
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

        internal AzureCredentials GetAzureCredentials()
        {
            return SdkContext.AzureCredentialsFactory.FromServicePrincipal(
                ClientId, ClientSecret, TenantId, AzureEnvironment.AzureGlobalCloud);
        } 
    }
}
