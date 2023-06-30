using System.Threading.Tasks;
using FruitMarket.API.Domain.Repositories;
using FruitMarket.API.Persistence.Contexts;

namespace FruitMarket.API.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;     
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}