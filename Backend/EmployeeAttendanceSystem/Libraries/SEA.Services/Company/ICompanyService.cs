using SEA.Core.Models;

namespace SEA.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>?> GetCompany();
    }
}
