using System.Threading.Tasks;
using FruitMarket.API.Domain.Models;
using FruitMarket.API.Domain.Models.Queries;
using FruitMarket.API.Domain.Services.Communication;

namespace FruitMarket.API.Domain.Services
{
    public interface IProductService
    {
        Task<QueryResult<Product>> ListAsync(ProductsQuery query);
        Task<ProductResponse> SaveAsync(Product product);
        Task<ProductResponse> UpdateAsync(int id, Product product);
        Task<ProductResponse> DeleteAsync(int id);
    }
}