using System.Threading.Tasks;

namespace OasisWebApp.Interfaces
{
    public interface IDelete <in TKey>
    {
        Task DeleteAsync(TKey id);
    }
}
