using API_Markel.Data.DTOs;
using API_Markel.Data.Requests;
using Bogus;

namespace API_Markel.Data.Repositories
{
    public class ClaimsRepository : IClaimsRepository
    {
        public List<ClaimTypeDTO> ClaimTypes { get; set; }
        public List<ClaimsDTO> Claims { get; set; }
        public ClaimsRepository()
        {
            var claimTypeIds = 1;
            var testClaimTypes = new Faker<ClaimTypeDTO>()
                .RuleFor(c => c.Id, f => claimTypeIds++)
                .RuleFor(c => c.Name, f => f.Finance.AccountName());
            ClaimTypes = testClaimTypes.Generate(5);

            var testClaims = new Faker<ClaimsDTO>()
                .StrictMode(true)
                .RuleFor(c => c.UCR, f => Guid.NewGuid().ToString().Substring(0, 20))
                .RuleFor(c => c.CompanyId, f => f.Random.Number(1, 10))
                .RuleFor(c => c.AssuredName, f => f.Company.CompanyName())
                .RuleFor(c => c.LossDate, f => f.Date.Past(2, DateTime.UtcNow.AddYears(-1)))
                .RuleFor(c => c.ClaimDate, f => f.Date.Recent().ToUniversalTime())
                .RuleFor(c => c.IncurredLoss, f => f.Finance.Amount(0, 999999999999999, 2))
                .RuleFor(c => c.Closed, f => f.Random.Number(1));
            Claims = testClaims.Generate(100);
        }

        public ClaimsDTO GetClaimById(string id)
        {
            return Claims.FirstOrDefault(c => c.UCR == id);
        }

        public List<ClaimsDTO> GetClaimsByCompanyId(int companyId)
        {
            return Claims.Where(c => c.CompanyId == companyId).ToList();
        }

        public ClaimsDTO UpdateClaim(string id, UpdateClaimRequest updatedClaim)
        {
            var claim = GetClaimById(id);
            if (claim == null)
            {
                return null;
            }

            claim.IncurredLoss = updatedClaim.IncurredLoss ?? 0;
            claim.Closed = updatedClaim.Closed? 0 : 1;

            return claim;
        }
    }
}
