using Microsoft.AspNetCore.Mvc;
using Rajanell.ClientAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rajanell.ClientAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccessTokensController : Controller
    {
        private readonly IIdentityService _identityService;

        public AccessTokensController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (string.IsNullOrEmpty(Request.Headers["ClientId"]) || string.IsNullOrEmpty(Request.Headers["ClientSecret"]))
                return BadRequest();

            var authToken = await _identityService.GetAccessToken(Request.Headers["ClientId"], Request.Headers["ClientSecret"]);
            return Ok(authToken);
        }
    }
}
