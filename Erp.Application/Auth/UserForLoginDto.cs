using Erp.Application.Common.Mappings;
using Erp.Application.Auth.Commands;

namespace Erp.Application.Auth
{
    public class UserForLoginDto : IMapFrom<LoginUser>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TokenNumber { get; set; }
        public int BranchOfficeId { get; set; }
        public int FinYearId { get; set; }
        public string BranchOfficeName { get; set; }
        public string Token { get; set; }
    }
}
