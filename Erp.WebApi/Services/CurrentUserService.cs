using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Erp.Application.Auth.RoleManagement;
using Erp.Application.Common.Interfaces;
using Erp.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Erp.WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            UserId = Convert.ToInt32(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));
            EmployeeId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.SerialNumber);
            UserName = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
            HeadOfficeId = Convert.ToInt32(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.GroupSid));
            BranchOfficeId = Convert.ToInt32(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.PrimarySid));
            FinYearId = Convert.ToInt32(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.PrimaryGroupSid));
            IpAddress = GetClientIp(httpContextAccessor,configuration);

        }


        public int UserId { get; }
        public string EmployeeId { get; }
        public string UserName { get; }
        public int HeadOfficeId { get; }
        public int BranchOfficeId { get; }
        public int FinYearId { get; }
        public string IpAddress { get; set; }


        public string GetClientIp(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            var ipAddress = httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress;

            // If the IP address is an IPv6 loopback (::1), get the local IPv4 address instead
            if (ipAddress != null)
            {
                if (ipAddress.IsIPv6LinkLocal || ipAddress.IsIPv6Multicast || ipAddress.IsIPv6SiteLocal || ipAddress.IsIPv6Teredo || ipAddress.ToString() == "::1")
                {
                    // Retrieve the IPv4 address instead of IPv6
                    ipAddress = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName())
                                                 .AddressList
                                                 .FirstOrDefault(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                }
            }

            // Check the X-Forwarded-For header for load-balancer/proxy scenarios
            var forwardedIp = httpContextAccessor.HttpContext?.Request?.Headers["X-Forwarded-For"].ToString().Split(',').FirstOrDefault();

            // Use forwarded IP if available, otherwise use the local IP address we retrieved
            return !string.IsNullOrEmpty(forwardedIp) ? forwardedIp : ipAddress?.ToString() ?? "IP Not Found";
        }

    }
}
