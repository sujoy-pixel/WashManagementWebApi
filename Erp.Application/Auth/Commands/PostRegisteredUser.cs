using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Auth.Commands
{
    public class PostRegisteredUser : IRequest<int>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string EmployeeCode { get; set; }
        public string Password { get; set; }
        public DateTime Doj { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public string Photo { get; set; }
    }
}
