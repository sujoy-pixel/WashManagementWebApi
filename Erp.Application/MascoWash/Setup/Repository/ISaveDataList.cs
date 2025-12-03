using Erp.Application.Common.Models;
using Erp.Application.MascoWash.Commands;
using Erp.Application.MascoWash.Queries;
using Erp.Application.Requests.ErpApp.SCHOOL.User;
using Erp.Domain.Entities.Commercial.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.MascoWash.Setup.Repository
{
    public interface ISaveDataList
    {
        Task<Result> CreateDataList(SaveDataListDto saveDataListDto);


        Task<WrapperResponseProcessName> saveProcessNameEntryData(saveProcessNameData saveDataListDto);
        Task<List<ProcessNameEntryGetList>> GetProcessNameEntryList();
        Task<List<DropdownListDto1>> GetUnitNameList();

        Task<WrapperResponseOperationName> saveOperationNameEntryData(saveOperationNameData saveDataListDto);
        Task<List<OperationNameEntryGetList>> GetOperationNameEntryList();

        Task<WrapperResponseTypeofInspection> saveTypeofInspectionData(saveTypeofInspectionData saveDataListDto);
        Task<List<TypeofInspectionGetList>> GetTypeofInspectionList();

        Task<WrapperResponseInspectionArea> saveInspectionAreaData(saveInspectionAreaData saveDataListDto);
        Task<List<InspectionAreaGetList>> GetInspectionAreaList();
    }
}
