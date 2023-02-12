using API_Markel.Data.Models;
using API_Markel.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Markel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyClaimsService _companyClaimsService;

        public CompanyController(ICompanyClaimsService companyClaimsService)
        {
            _companyClaimsService = companyClaimsService;
        }

        [HttpGet("{id}")]
        public ActionResult<Company> GetCompany(int id)
        {
            var company = _companyClaimsService.GetCompany(id);

            return company == null ? NotFound() : company;
        }

        [HttpGet("{companyId}/claims")]
        public ActionResult<List<Claims>> GetClaimsByCompanyId(int companyId)
        {
            return _companyClaimsService.GetClaimsByCompany(companyId);
        }
    }
}
