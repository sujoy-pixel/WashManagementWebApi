using System;
using System.Threading.Tasks;
using Erp.Application.Common.Interfaces;
using Erp.Application.MascoWash.Setup.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Erp.WebApi.Controllers
{
    /// <summary>
    /// Builds the GatePass link that signs the current Wash user in, in the
    /// "?username=&amp;pass=" form GatePass already accepts
    /// (e.g. /FabricIssue/Index?username=132134&amp;pass=Y4A%2fly3I1tWKyxdKeOAHig%3d%3d).
    /// Username + encrypted password come from sp_GetUserCredentialByIdForWash.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GatePassSsoController : ControllerBase
    {
        private readonly ICurrentUserService _currentUser;
        private readonly ISaveDataList _setup;
        private readonly IConfiguration _config;

        public GatePassSsoController(ICurrentUserService currentUser, ISaveDataList setup, IConfiguration config)
        {
            _currentUser = currentUser;
            _setup = setup;
            _config = config;
        }

        /// <summary>GET api/GatePassSso/Url?returnUrl=/WashDispatch/Index?MenuId=2484</summary>
        [HttpGet("Url")]
        public async Task<IActionResult> GetLoginUrl([FromQuery] string returnUrl)
        {
            // only relative paths inside GatePass - never an arbitrary redirect target
            if (string.IsNullOrWhiteSpace(returnUrl) || !returnUrl.StartsWith("/") || returnUrl.StartsWith("//"))
                return BadRequest("returnUrl must be a relative GatePass path, e.g. /WashDispatch/Index?MenuId=2484");

            if (string.IsNullOrWhiteSpace(_currentUser.EmployeeId))
                return Unauthorized("No employee code on the current login.");

            // sp_GetUserCredentialByIdForWash is in the ControlPanal database
            var (userName, password) = await _setup.GetGatePassCredential(
                _currentUser.EmployeeId, _config["GatePassSso:CredentialDatabase"] ?? "ControlPanal");
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                return NotFound("No GatePass credential found for this user.");

            var baseUrl = (_config["GatePassSso:BaseUrl"] ?? "https://mis-gp.mascoknit.com").TrimEnd('/');
            var separator = returnUrl.Contains("?") ? "&" : "?";

            var url = $"{baseUrl}{returnUrl}{separator}username={Uri.EscapeDataString(userName)}&pass={Uri.EscapeDataString(password)}";
            return Ok(new { url });
        }
    }
}
