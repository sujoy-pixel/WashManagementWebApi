using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.Requests.ErpApp.SCHOOL.File.Query
{
    public class FileTypeList : IRequest<List<FileTypeDto>>
    {
        public int Id { get; set; }
    }
}
