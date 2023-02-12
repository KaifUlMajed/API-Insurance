using API_Markel.Data.DTOs;
using API_Markel.Data.Models;
using Bogus;

namespace API_Markel.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public List<CompanyDTO> Companies { get; set; }

        public CompanyRepository()
        {
            var companyId = 1;
            var testCompanies = new Faker<CompanyDTO>()
                .StrictMode(true)
                .RuleFor(c => c.Active, f => f.Random.Number(1))
                .RuleFor(c => c.Address1, f => f.Address.StreetAddress())
                .RuleFor(c => c.Address2, f => f.Address.StreetAddress())
                .RuleFor(c => c.Address3, f => f.Address.StreetAddress())
                .RuleFor(c => c.Country, f => f.Address.Country())
                .RuleFor(c => c.Id, f => companyId++)
                .RuleFor(c => c.Name, f => f.Company.CompanyName())
                .RuleFor(c => c.PostCode, f => f.Address.ZipCode())
                .RuleFor(c => c.InsuranceEndDate, f => f.Date.Between(DateTime.UtcNow.AddYears(-5), DateTime.UtcNow.AddYears(5)));

            Companies = testCompanies.Generate(10);
        }

        public CompanyDTO GetCompanyById(int id)
        {
            return Companies.FirstOrDefault(c => c.Id == id);
        }
    }
}
