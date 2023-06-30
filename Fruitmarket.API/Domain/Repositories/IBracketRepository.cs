using System.Collections.Generic;
using System.Threading.Tasks;
using FruitMarket.API.Domain.Models;

namespace FruitMarket.API.Domain.Repositories
{
    public interface IBracketRepository
    {
        Task<IEnumerable<Bracket>> ListAsync();
        Task AddAsync(Bracket bracket);
        Task<Bracket> FindByIdAsync(int id);
        void Update(Bracket bracket);
        void Remove(Bracket bracket);
    }
}