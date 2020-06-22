using System.Threading.Tasks;

namespace OasisWebApp.Interfaces
{
    public interface IUpdate<TEntity>
        where TEntity : class
    {
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}