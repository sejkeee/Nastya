using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Authentication.Internal;
using Unity.Services.Core;
using Unity.Services.Relay.Apis.Allocations;
using Unity.Services.Relay.Http;
using Unity.Services.Relay.Models;
using UnityEngine;

namespace Unity.Services.Relay
{
    /// <summary>
    /// The Allocations Service enables clients to connect to relay servers. Once connected, they are able to communicate with each other, via the relay servers, using the bespoke relay binary protocol.
    /// </summary>
#pragma warning disable CS0618 // IRelayServiceSDK is obsolete, but we still want to implement it for backwards compatibility for now
    internal class WrappedRelayService : IRelayService, IRelayServiceSDK, IRelayServiceSDKConfiguration
#pragma warning restore CS0618
    {
        internal IRelayServiceSdk m_RelayService { get; set; }

        internal WrappedRelayService(IRelayServiceSdk relayService)
        {
            m_RelayService = relayService;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentException">Thrown when the maxConnections argument fails validation in SDK.</exception>
        public async Task<Allocation> CreateAllocationAsync(int maxConnections, string region = null)
        {
            EnsureSignedIn();

            if (maxConnections <= 0) 
            {
                throw new ArgumentException("Maximum number of connections for an allocation must be greater than 0!");
            }

            if (m_RelayService.QosService != null && string.IsNullOrEmpty(region))
            {
                try
                {
                    var regions = await ListRegionsAsync();
                    var orderedRegions = await m_RelayService.QosService.OrderRegionsByQoSAsync(regions);
                    if (orderedRegions != null && orderedRegions.Any())
                    {
                        region = orderedRegions[0].Id;
                    }
                }
                catch (Exception ex)
                {
                    Debug.Log($"Could not do Qos region selection. Will use default. Error[{ex.Message}]");
                }
            }

            try
            {
                var response = await m_RelayService.AllocationsApi.CreateAllocationAsync(new Allocations.CreateAllocationRequest(new AllocationRequest(maxConnections, region)), m_RelayService.Configuration);
                return response.Result.Data.Allocation;
            }
            catch (HttpException<ErrorResponseBody> e)
            {
                throw new RelayServiceException(e.ActualError.GetExceptionReason(), e.ActualError.GetExceptionMessage(), e);
            }
            catch (HttpException e)
            {
                if (e.Response.IsHttpError)
                {
                    throw new RelayServiceException(e.Response.GetExceptionReason(), e.Response.ErrorMessage, e);
                }

                if (e.Response.IsNetworkError)
                {
                    throw new RelayServiceException(RelayExceptionReason.NetworkError, e.Response.ErrorMessage);
                }

                throw new RequestFailedException((int)RelayExceptionReason.Unknown, "Something went wrong.", e);
            }
        }

        /// <inheritdoc/>
        /// <exception cref="RelayServiceException">Thrown when the request successfully reach the Relay Allocation Service but results in an errorr.</exception>
        /// <exception cref="RequestFailedException">Thrown when the request does not reach the Relay Allocation Service.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the allocationId argument fails validation in SDK.</exception>
        public async Task<string> GetJoinCodeAsync(Guid allocationId)
        {
            EnsureSignedIn();

            if (allocationId == null || allocationId == Guid.Empty) 
            {
                throw new ArgumentNullException("AllocationId cannot be null or empty!");
            }

            try
            {
                var response = await m_RelayService.AllocationsApi.CreateJoincodeAsync(new Allocations.CreateJoincodeRequest(new JoinCodeRequest(allocationId)), m_RelayService.Configuration);
                return response.Result.Data.JoinCode;
            }
            catch (HttpException<ErrorResponseBody> e)
            {
                throw new RelayServiceException(e.ActualError.GetExceptionReason(), e.ActualError.GetExceptionMessage(), e);
            }
            catch (HttpException e)
            {
                if (e.Response.IsHttpError)
                {
                    throw new RelayServiceException(e.Response.GetExceptionReason(), e.Response.ErrorMessage, e);
                }

                if (e.Response.IsNetworkError)
                {
                    throw new RelayServiceException(RelayExceptionReason.NetworkError, e.Response.ErrorMessage);
                }

                throw new RequestFailedException((int)RelayExceptionReason.Unknown, "Something went wrong.", e);
            }
        }

        /// <inheritdoc/>
        /// <exception cref="RelayServiceException">Thrown when the request successfully reach the Relay Allocation Service but results in an error.</exception>
        /// <exception cref="RequestFailedException">Thrown when the request does not reach the Relay Allocation Service.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the joinCode argument fails validation in SDK.</exception>
        public async Task<JoinAllocation> JoinAllocationAsync(string joinCode)
        {
            EnsureSignedIn();

            if (string.IsNullOrWhiteSpace(joinCode)) 
            {
                throw new ArgumentNullException("JoinCode must be non-null, non-empty, and cannot contain only whitespace!");
            }

            try
            {
                var response = await m_RelayService.AllocationsApi.JoinRelayAsync(new Allocations.JoinRelayRequest(new JoinRequest(joinCode)), m_RelayService.Configuration);

                return response.Result.Data.Allocation;
            }
            catch (HttpException<ErrorResponseBody> e)
            {
                throw new RelayServiceException(e.ActualError.GetExceptionReason(), e.ActualError.GetExceptionMessage(), e);
            }
            catch (HttpException e)
            {
                if (e.Response.IsHttpError)
                {
                    throw new RelayServiceException(e.Response.GetExceptionReason(), e.Response.ErrorMessage, e);
                }

                if (e.Response.IsNetworkError)
                {
                    throw new RelayServiceException(RelayExceptionReason.NetworkError, e.Response.ErrorMessage);
                }

                throw new RequestFailedException((int)RelayExceptionReason.Unknown, "Something went wrong.", e);
            }
        }

        /// <inheritdoc/>
        /// <exception cref="RelayServiceException">Thrown when the request successfully reach the Relay Allocation Service but results in an error.</exception>
        /// <exception cref="RequestFailedException">Thrown when the request does not reach the Relay Allocation Service.</exception>
        public async Task<List<Region>> ListRegionsAsync()
        {
            EnsureSignedIn();

            try
            {
                var response = await m_RelayService.AllocationsApi.ListRegionsAsync(new Allocations.ListRegionsRequest(), m_RelayService.Configuration);

                return response.Result.Data.Regions;
            }
            catch (HttpException<ErrorResponseBody> e)
            {
                throw new RelayServiceException(e.ActualError.GetExceptionReason(), e.ActualError.GetExceptionMessage(), e);
            }
            catch (HttpException e)
            {
                if (e.Response.IsHttpError)
                {
                    throw new RelayServiceException(e.Response.GetExceptionReason(), e.Response.ErrorMessage, e);
                }

                if (e.Response.IsNetworkError)
                {
                    throw new RelayServiceException(RelayExceptionReason.NetworkError, e.Response.ErrorMessage);
                }

                throw new RequestFailedException((int)RelayExceptionReason.Unknown, "Something went wrong.", e);
            }
        }

        public void SetAllocationsServiceBasePath(string allocationsBasePath)
        {
            this.m_RelayService.Configuration.BasePath = allocationsBasePath;
        }
        
        private void EnsureSignedIn()
        {
            if (m_RelayService.AccessToken.AccessToken == null)
            {
                throw new RelayServiceException(RelayExceptionReason.Unauthorized, "You are not signed in to the Authentication Service. Please sign in.");
            }
        }
    }
}