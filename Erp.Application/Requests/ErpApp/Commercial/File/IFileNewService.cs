using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.Requests.ErpApp.SCHOOL.File
{
    public interface IFileNewService 
    {
        Task<List<FileTypeDto>> GetFileTypeList();
    }
}
