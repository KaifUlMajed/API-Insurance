using API_Markel.Data.Models;
using API_Markel.Data.Requests;
using API_Markel.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Markel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly ICompanyClaimsService _companyClaimsService;

        public ClaimsController(ICompanyClaimsService companyClaimsService)
        {
            _companyClaimsService = companyClaimsService;
        }

        [HttpGet("{claimId}")]
        public ActionResult<Claims> GetClaimById(string claimId)
        {
            var claim = _companyClaimsService.GetClaim(claimId);

            return claim == null ? NotFound() : claim;
        }

        [HttpPut("{claimId}")]
        public ActionResult<Claims> GetClaimById(string claimId, [FromBody] UpdateClaimRequest updatedClaim)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var claim = _companyClaimsService.UpdateClaim(claimId, updatedClaim);
            
            return claim == null ? NotFound() : claim;
        }
    }
}
