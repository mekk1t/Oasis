using System.Threading.Tasks;

namespace OasisWebApp.Interfaces
{
    public interface ICreate<TEntity>
       where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
    }
}