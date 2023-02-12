using API_Markel.Data.DTOs;

namespace API_Markel.Data.Repositories
{
    public interface ICompanyRepository
    {
        List<CompanyDTO> Companies { get; set; }

        CompanyDTO GetCompanyById(int id);
    }
}