using System.Collections.Generic;
using System.Threading.Tasks;

namespace OasisWebApp.Interfaces
{
    public interface IFind<TEntity, TFilter>
            where TFilter : class
    {
        Task<IEnumerable<TEntity>> FindAsync(TFilter filter = null);
    }
}