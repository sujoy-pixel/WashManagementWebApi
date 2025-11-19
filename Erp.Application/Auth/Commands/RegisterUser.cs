using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using Erp.Application.Common.Interfaces;
using Erp.Application.Common.Models;

using MediatR;

namespace Erp.Application.Auth.Commands
{
    public class RegisterUser : IRequest<Result>
    {
        [Required]
        public string EmployeeId { get; set; }

        //[Required]
        //public string UserName { get; set; }

        [Required]
        public string Password { get; set; }


        //[Required]
        //public string Email { get; set; }

        //[Required]
        //public int HeadOfficeId { get; set; }
        //[Required]
        public int BranchOfficeId { get; set; } = 1;

        public RegisterUser()
        {

        }


        public RegisterUser(string employeeId, string userName, string password, string email, int headOfficeId,
            int branchOfficeId)
        {

            EmployeeId = employeeId;
            // UserName = employeeId;
            Password = password;
            //Email = email;
            //HeadOfficeId = headOfficeId;
            BranchOfficeId = branchOfficeId;


        }


    }
}
