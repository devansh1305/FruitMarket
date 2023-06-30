using System.Threading.Tasks;

namespace FruitMarket.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}