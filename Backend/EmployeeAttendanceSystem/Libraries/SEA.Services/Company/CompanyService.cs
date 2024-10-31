using SEA.Core;
using SEA.Core.Models;

namespace SEA.Services
{
    public class CompanyService : ICompanyService
    {
        private IRepository<Company> _companyRepository;
        public CompanyService(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<IEnumerable<Company>?> GetCompany()
        {
            return await _companyRepository.GetAllAsync();
        }
    }
}

