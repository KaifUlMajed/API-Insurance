using API_Markel.Data.Models;
using API_Markel.Data.Repositories;
using API_Markel.Data.Requests;
using AutoMapper;

namespace API_Markel.Data.Services
{
    public class CompanyClaimsService : ICompanyClaimsService
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
        private readonly IClaimsRepository _claimsRepository;

        public CompanyClaimsService(IMapper mapper, ICompanyRepository companyRepository, IClaimsRepository claimsRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
            _claimsRepository = claimsRepository;
        }

        public Company GetCompany(int id)
        {
            var company = _companyRepository.GetCompanyById(id);
            return company != null ? _mapper.Map<Company>(company) : null;
        }

        public Claims GetClaim(string id)
        {
            return _mapper.Map<Claims>(_claimsRepository.GetClaimById(id));
        }

        public List<Claims> GetClaimsByCompany(int companyId)
        {
            var claims = _claimsRepository.GetClaimsByCompanyId(companyId);
            return _mapper.Map<List<Claims>>(claims);
        }

        public Claims UpdateClaim(string id, UpdateClaimRequest updatedClaim)
        {
            var claims = _claimsRepository.UpdateClaim(id, updatedClaim);
            return claims != null ? _mapper.Map<Claims>(claims) : null;
        }
    }
}
