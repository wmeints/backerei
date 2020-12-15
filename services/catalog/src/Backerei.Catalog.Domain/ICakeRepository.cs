using System.Threading.Tasks;

namespace Backerei.Catalog.Domain
{
    /// <summary>
    /// Persistence interface for cakes.
    /// </summary>
    public interface ICakeRepository
    {
        Task<Cake> InsertAsync(Cake cake);
        Task<Cake> UpdateAsync(Cake cake);
        Task<Cake> DeleteAsync(Cake cake);
    }
}