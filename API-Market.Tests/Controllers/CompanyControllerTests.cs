using API_Markel.Controllers;
using API_Markel.Data.Models;
using API_Markel.Data.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;
using Xunit;

namespace API_Market.Tests.Controllers
{
    public class CompanyControllerTests
    {
        private readonly Mock<ICompanyClaimsService> _companyClaimsService = new();
        private readonly CompanyController _companyController;

        public CompanyControllerTests()
        {
            var company = new Company
            {
                Id = 1,
                Addresses = new List<string> { "address_1" },
                Country = "country",
                HasActiveInsurancePolicy = true,
                InsuranceEndDate = new DateTime(2023, 1, 1),
                Name = "Company_name",
                PostCode = "post_code"
            };

            var claims = new List<Claims>
            {
                new Claims
                {
                    AssuredName = "assured_name",
                    Closed = true,
                    AgeOfClaimInDays = 1,
                    ClaimDate = new DateTime(2023, 1, 1),
                    CompanyId = 1,
                    IncurredLoss = 123.45M,
                    LossDate = new DateTime(2022, 1, 1),
                    UCR = "ucr"
                }
            };

            _companyClaimsService.Setup(x => x.GetCompany(It.IsAny<int>()))
                .Returns(company);

            _companyClaimsService.Setup(x => x.GetClaimsByCompany(It.IsAny<int>()))
                .Returns(claims);

            _companyController = new CompanyController(_companyClaimsService.Object);
        }

        [Fact]
        public void GetCompany_returns_a_company_when_it_exists()
        {
            var expected = new Company
            {
                Id = 1,
                Addresses = new List<string> { "address_1" },
                Country = "country",
                HasActiveInsurancePolicy = true,
                InsuranceEndDate = new DateTime(2023, 1, 1),
                Name = "Company_name",
                PostCode = "post_code"
            };

            var result = _companyController.GetCompany(1);

            result.Value.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GetCompany_returns_not_found_when_company_does_not_exist()
        {
            _companyClaimsService.Setup(x => x.GetCompany(It.IsAny<int>()))
                .Returns(null as Company);

            var result = _companyController.GetCompany(1);

            result.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void GetClaimsByCompanyId_returns_the_claims_for_a_company()
        {
            var expected = new List<Claims>
            {
                new Claims
                {
                    AssuredName = "assured_name",
                    Closed = true,
                    AgeOfClaimInDays = 1,
                    ClaimDate = new DateTime(2023, 1, 1),
                    CompanyId = 1,
                    IncurredLoss = 123.45M,
                    LossDate = new DateTime(2022, 1, 1),
                    UCR = "ucr"
                }
            };

            var result = _companyController.GetClaimsByCompanyId(1);

            result.Value.Should().BeEquivalentTo(expected);
        }
    }
}
