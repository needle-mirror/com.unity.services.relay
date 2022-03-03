using System;
using System.Runtime.CompilerServices;
using Unity.Services.Authentication.Internal;
#if USE_QOS
using Unity.Services.Relay.Qos;
#endif

[assembly: InternalsVisibleTo("Unity.Services.Relay.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Unity.Services.Relay
{
    /// <summary>
    /// The entry class of the Relay Allocations Service enables clients to connect to relay servers. Once connected, they are able to communicate with each other, via the relay servers, using the bespoke relay binary protocol.
    /// </summary>
    public static class RelayService
    {
        private static IRelayService service;
        
        private static readonly Configuration allocationsApiConfiguration;

#if USE_QOS
        private static readonly Qos.Configuration qosDiscoveryApiConfiguration;
#endif

        static RelayService()
        {
#if AUTHENTICATION_TESTING_STAGING_UAS
            allocationsApiConfiguration = new Configuration("https://relay-allocations-stg.services.api.unity.com", 10, 4, null);
#if USE_QOS
            qosDiscoveryApiConfiguration = new Qos.Configuration("https://qos-discovery-stg.services.api.unity.com", 10, 4, null);
#endif // USE_QOS
#else // AUTHENTICATION_TESTING_STAGING_UAS
            allocationsApiConfiguration = new Configuration("https://relay-allocations.services.api.unity.com", 10, 4, null);
#if USE_QOS
            qosDiscoveryApiConfiguration = new Qos.Configuration("https://qos-discovery.services.api.unity.com", 10, 4, null);
#endif // USE_QOS
#endif // AUTHENTICATION_TESTING_STAGING_UAS
        }

        /// <summary>
        /// A static instance of the Relay Allocation Client.
        /// </summary>
        public static IRelayService Instance
        {
            get
            {
                if (service != null)
                {
                    return service;
                }

                service = new WrappedRelayService(RelayServiceSdk.Instance);

                return service;
            }
        }
    }

    /// <summary>
    /// "Relay class is marked for deprecation. Please use RelayService class instead."
    /// </summary>
    //[Obsolete("Relay class is marked for deprecation. Please use RelayService class instead.")]
    public static class Relay
    {
        /// <summary>
        /// Relay class is marked for deprecation. Please use RelayService.Instance instead.
        /// </summary>
        //[Obsolete("Relay class is marked for deprecation. Please use RelayService.Instance instead.")]
        public static IRelayServiceSDK Instance { get { return (IRelayServiceSDK) RelayService.Instance; } }
    }
}
