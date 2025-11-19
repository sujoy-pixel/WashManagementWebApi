using Erp.Application.Common.Mappings;
using Erp.Application.Auth.Commands;

namespace Erp.Application.Auth
{
    public class UserForRegisterDto : IMapFrom<RegisterUser>
    {
        public string EmployeeId { get; set; }
        //public string Email { get; set; }
        //public string UserName { get; set; }
        public string Password { get; set; }
        //public string PhoneNumber { get; set; }

        //public int HeadOfficeId { get; set; }
        public int BranchOfficeId { get; set; }


    }
}
