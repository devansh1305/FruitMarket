using System.Collections.Generic;
using System.Threading.Tasks;
using FruitMarket.API.Domain.Models;
using FruitMarket.API.Domain.Services.Communication;

namespace FruitMarket.API.Domain.Services
{
    public interface IBracketService
    {
         Task<IEnumerable<Bracket>> ListAsync();
         Task<BracketResponse> SaveAsync(Bracket bracket);
         Task<BracketResponse> UpdateAsync(int id, Bracket bracket);
         Task<BracketResponse> DeleteAsync(int id);
    }
}