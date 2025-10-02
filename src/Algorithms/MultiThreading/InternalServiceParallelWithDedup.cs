using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithms.MultiThreading
{
    public class InternalServiceParallelWithDedup : IInternalService
    {
        private IExternalService _externalService;
        private ICacheService _cacheService;
        // Track external requests that are pending, i.e., not completed yet.
        ConcurrentDictionary<string, decimal> _activeRequests;

        public InternalServiceParallelWithDedup(IExternalService externalService, ICacheService cacheService)
        {
            this._externalService = externalService ?? throw new ArgumentNullException(nameof(externalService));
            this._cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
            this._activeRequests = new ConcurrentDictionary<string, decimal>();
        }
        public async Task<IDictionary<string, decimal>> GetPrices(IList<string> items)
        {
            ConcurrentDictionary<string, decimal> prices = new ConcurrentDictionary<string, decimal>();

            IEnumerable<Task> tasks = items.Select(async item => {
                // Check if there is a pending request already,
                // if so, try again in 1.5 seconds as we know the external service latency is roughly 1 second.
                // Set a retry limit of 3.
                int retryCount = 0;
                if (_activeRequests.ContainsKey(item))
                {
                    retryCount++;
                    await Task.Delay(1500);

                    if (retryCount > 3)
                    {
                        throw new ApplicationException("Max retry exceeded. Please try again later.");
                    }
                }

                // Get price either from cache or from external service
                decimal price;
                if (_cacheService.TryGetValue(item, out price))
                {
                    // Cache hit
                    prices.TryAdd(item, price);
                }
                else
                {
                    // Handle cache miss
                    // Add our item to pending external requests
                    _activeRequests.TryAdd(item, -1.0m);
                    
                    price = await _externalService.GetPrice(item);
                    prices[item] = price;

                    // Set cache
                    _cacheService.Set(item, price);

                    // Remove current item from pending external requests
                    _activeRequests.TryRemove(item, out _);
                }
            });

            await Task.WhenAll(tasks);
            return prices;
        }
    }
}
