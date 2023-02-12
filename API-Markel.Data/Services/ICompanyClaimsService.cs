using API_Markel.Data.Models;
using API_Markel.Data.Requests;

namespace API_Markel.Data.Services
{
    public interface ICompanyClaimsService
    {
        Claims GetClaim(string id);
        List<Claims> GetClaimsByCompany(int companyId);
        Company GetCompany(int id);
        Claims UpdateClaim(string id, UpdateClaimRequest updatedClaim);
    }
}