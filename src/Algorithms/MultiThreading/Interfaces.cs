using System.Collections.Generic;
using System.Threading.Tasks;

namespace Algorithms.MultiThreading
{
    public interface IInternalService
    {
        Task<IDictionary<string, decimal>> GetPrices(IList<string> items);
    }
    public interface IExternalService
    {
        Task<decimal> GetPrice(string item);
    }

    public interface ICacheService
    {
        void Add(string key, decimal value);
        bool TryGetValue(string key, out decimal value);
        void Set(string key, decimal value);
    }
}
