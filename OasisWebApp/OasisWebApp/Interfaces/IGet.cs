using System.Threading.Tasks;

namespace OasisWebApp.Interfaces
{
    public interface IGet<TEntity, TFilter, in TKey>
        where TEntity : class
        where TFilter : class
    {
        Task<TEntity> GetAsync(TKey id, TFilter filter = null);
    }
}