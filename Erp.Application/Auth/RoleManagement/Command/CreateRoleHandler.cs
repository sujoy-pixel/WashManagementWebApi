using Erp.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.Auth.RoleManagement.Command
{
  
    public class CreateMenuPermission : IRequest<Result>
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public int ParentId { get; set; }
        public int ActiveStatus { get; set; }
        public int SortOrder { get; set; }
        public string Url { get; set; }
        public string Remarks { get; set; }
        public string Icon { get; set; }
        public string Type { get; set; }
    }


}
