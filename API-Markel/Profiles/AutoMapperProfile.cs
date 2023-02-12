using API_Markel.Data.DTOs;
using API_Markel.Data.Models;
using AutoMapper;

namespace API_Markel.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CompanyDTO, Company>()
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => new List<string> { src.Address1, src.Address2, src.Address3 }.Where(address => !string.IsNullOrEmpty(address)).ToList()))
                .ForMember(dest => dest.HasActiveInsurancePolicy, opt => opt.MapFrom(src => src.InsuranceEndDate > DateTime.UtcNow));

            CreateMap<ClaimsDTO, Claims>()
                .ForMember(dest => dest.Closed, opt => opt.MapFrom(src => src.Closed == 0))
                .ForMember(dest => dest.AgeOfClaimInDays, opt => opt.MapFrom(src => (DateTime.UtcNow - src.ClaimDate).TotalDays));

            CreateMap<ClaimTypeDTO, ClaimType>();
        }
    }
}
