using API_Markel.Data.DTOs;
using API_Markel.Data.Models;
using API_Markel.Data.Repositories;
using API_Markel.Data.Services;
using API_Markel.Profiles;
using AutoMapper;
using FluentAssertions;
using Moq;
using Xunit;

namespace API_Market.Tests.Services
{
    public class CompanyClaimsServiceTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICompanyRepository> _companyRepository = new();
        private readonly Mock<IClaimsRepository> _claimsRepository = new();
        private readonly CompanyClaimsService _companyClaimsService;

        private CompanyDTO _company;
        public CompanyClaimsServiceTests()
        {
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile())).CreateMapper();

            _company = new CompanyDTO
            {
                Active = 0,
                Address1 = "address_1",
                Address2 = "address_2",
                Address3 = "",
                Country = "country",
                Id = 1,
                InsuranceEndDate = new DateTime(2025, 1, 1),
                Name = "company_name",
                PostCode = "post_code"
            };

            _companyRepository.Setup(x => x.GetCompanyById(It.IsAny<int>()))
                .Returns(_company);

            _companyClaimsService = new(_mapper, _companyRepository.Object, _claimsRepository.Object);

        }

        [Fact]
        public void GetCompany_returns_a_company_if_it_exists()
        {
            var expected = new Company
            {
                Id = 1,
                Addresses = new List<string> { "address_1", "address_2" },
                Country = "country",
                HasActiveInsurancePolicy = true,
                InsuranceEndDate = new DateTime(2025, 1, 1),
                Name = "company_name",
                PostCode = "post_code"
            };

            var result = _companyClaimsService.GetCompany(1);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetCompany_a_company_does_not_have_an_active_insurance_policy_if_endDate_in_the_past()
        {
            _company.InsuranceEndDate = new DateTime(2022, 12, 31);

            var result = _companyClaimsService.GetCompany(1);

            result.HasActiveInsurancePolicy.Should().BeFalse();
        }
    }
}
