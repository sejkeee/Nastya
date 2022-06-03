//-----------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by the C# SDK Code Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------


using UnityEngine;
using System.Threading.Tasks;

using Unity.Services.Relay.Qos.Apis.QosDiscovery;

using Unity.Services.Relay.Qos.Http;
using Unity.Services.Core.Internal;
using Unity.Services.Authentication.Internal;

namespace Unity.Services.Relay.Qos
{
    internal class QosDiscoveryServiceProvider : IInitializablePackage
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Register()
        {
            // Pass an instance of this class to Core
            var generatedPackageRegistry =
            CoreRegistry.Instance.RegisterPackage(new QosDiscoveryServiceProvider());
                // And specify what components it requires, or provides.
            generatedPackageRegistry.DependsOn<IAccessToken>();
;
        }

        public Task Initialize(CoreRegistry registry)
        {
            var httpClient = new HttpClient();

            var accessTokenQosDiscovery = registry.GetServiceComponent<IAccessToken>();

            if (accessTokenQosDiscovery != null)
            {
                QosDiscoveryService.Instance =
                    new InternalQosDiscoveryService(httpClient, registry.GetServiceComponent<IAccessToken>());
            }

            return Task.CompletedTask;
        }
    }

    /// <summary>
    /// InternalQosDiscoveryService
    /// </summary>
    internal class InternalQosDiscoveryService : IQosDiscoveryService
    {
        /// <summary>
        /// Constructor for InternalQosDiscoveryService
        /// </summary>
        /// <param name="httpClient">The HttpClient for InternalQosDiscoveryService.</param>
        /// <param name="accessToken">The Authentication token for the service.</param>
        public InternalQosDiscoveryService(HttpClient httpClient, IAccessToken accessToken = null)
        {
            
            QosDiscoveryApi = new QosDiscoveryApiClient(httpClient, accessToken);
            
            Configuration = new Configuration("https://qos-discovery.services.api.unity.com", 10, 4, null);
        }
        
        /// <summary> Instance of IQosDiscoveryApiClient interface</summary>
        public IQosDiscoveryApiClient QosDiscoveryApi { get; set; }
        
        /// <summary> Configuration properties for the service.</summary>
        public Configuration Configuration { get; set; }
    }
}
