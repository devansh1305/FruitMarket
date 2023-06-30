using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FruitMarket.API.Domain.Models;
using FruitMarket.API.Domain.Repositories;
using FruitMarket.API.Persistence.Contexts;

namespace FruitMarket.API.Persistence.Repositories
{
    public class BracketRepository : BaseRepository, IBracketRepository
    {
        public BracketRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Bracket>> ListAsync()
        {
            return await _context.Brackets
                                 .AsNoTracking()
                                 .ToListAsync();

            // AsNoTracking tells EF Core it doesn't need to track changes on listed entities. Disabling entity
            // tracking makes the code a little faster
        }

        public async Task AddAsync(Bracket bracket)
        {
            await _context.Brackets.AddAsync(bracket);
        }

        public async Task<Bracket> FindByIdAsync(int id)
        {
            return await _context.Brackets.FindAsync(id);
        }

        public void Update(Bracket bracket)
        {
            _context.Brackets.Update(bracket);
        }

        public void Remove(Bracket bracket)
        {
            _context.Brackets.Remove(bracket);
        }
    }
}