using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Algorithms.MultiThreading
{
    public class InternalServiceSequential : IInternalService
    {
        private IExternalService _externalService;
        private ICacheService _cacheService;

        public InternalServiceSequential(IExternalService externalService, ICacheService cacheService)
        {
            this._externalService = externalService ?? throw new ArgumentNullException(nameof(externalService));
            this._cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
        }
        public async Task<IDictionary<string, decimal>> GetPrices(IList<string> items)
        {
            IDictionary<string, decimal> prices = new Dictionary<string, decimal>();

            foreach (string item in items)
            {
                decimal price;
                if (_cacheService.TryGetValue(item, out price))
                {
                    // Cache hit
                    prices.Add(item, price);
                }
                else
                { 
                    // Cache miss
                    price = await _externalService.GetPrice(item);
                    prices[item] = price;

                    // Set cache
                    _cacheService.Set(item, price);
                }
            }

            return prices;
        }
    }
}
