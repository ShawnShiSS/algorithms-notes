using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithms.MultiThreading
{
    public class InternalServiceParallel : IInternalService
    {
        private IExternalService _externalService;
        private ICacheService _cacheService;
        public InternalServiceParallel(IExternalService externalService, ICacheService cacheService)
        {
            this._externalService = externalService ?? throw new ArgumentNullException(nameof(externalService));
            this._cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
        }
        public async Task<IDictionary<string, decimal>> GetPrices(IList<string> items)
        {
            ConcurrentDictionary<string, decimal> prices = new ConcurrentDictionary<string, decimal>();

            IEnumerable<Task> tasks = items.Select(async item => {
                decimal price;
                if (_cacheService.TryGetValue(item, out price))
                {
                    // Cache hit
                    prices.TryAdd(item, price);
                }
                else
                {
                    // Cache miss
                    price = await _externalService.GetPrice(item);
                    prices[item] = price;

                    // Set cache
                    _cacheService.Set(item, price);
                }
            });

            await Task.WhenAll(tasks);
            return prices;
        }
    }
}
