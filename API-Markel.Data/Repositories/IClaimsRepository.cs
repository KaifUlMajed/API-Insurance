using API_Markel.Data.DTOs;
using API_Markel.Data.Requests;

namespace API_Markel.Data.Repositories
{
    public interface IClaimsRepository
    {
        List<ClaimsDTO> Claims { get; set; }

        ClaimsDTO GetClaimById(string id);
        List<ClaimsDTO> GetClaimsByCompanyId(int companyId);
        ClaimsDTO UpdateClaim(string id, UpdateClaimRequest updatedClaim);
    }
}