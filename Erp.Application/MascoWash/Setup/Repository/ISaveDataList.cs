using Erp.Application.Auth.RoleManagement;
using Erp.Application.Commercial.Setup.Command;
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

        Task<WrapperResponseFaultHead> saveFaultHeadData(saveFaultHeadData saveDataListDto);
        Task<List<FaultHeadGetList>> GetFaultHeadList();

        Task<WrapperResponseInspectionHead> saveInspectionHeadData(saveInspectionHeadData saveDataListDto);
        Task<List<InspectionHeadGetList>> GetInspectionHeadList();

        Task<List<DropdownListDto1>> GetFaultHeadDDLList();
        Task<WrapperResponseFaultName> saveFaultNameData(saveFaultNameData saveDataListDto);
        Task<List<FaultNameGetList>> GetFaultNameList();

        Task<List<DropdownListDto1>> GetInspectionHeadDDLList();
        Task<List<DropdownListDto1>> GetOperationNameDDLList();
        Task<Result> saveMachineName(SaveMachineName saveDataListDto);
        Task<WrapperResponseFaultWiseValueTag> saveFaultWiseValueTagData(saveFaultWiseValueTagData saveDataListDto);
        Task<List<MachineDuplicateCheckModel>> CheckMachineExists(int unitId, int operationId,string machineName);
        Task<List<MachineMasterDetailModel>> GetMachineMasterList();

        Task<List<FaultWiseValueTagDetailGetAll>> GetFaultWiseValueTagList();

        Task<List<FaultWiseValueTagDetailGetAll>> GetFaultWiseValueTagListByFaultWiseMasterId(int FaultWiseMasterId);

        Task<List<DropdownListDto1>> GetBuyerDDLList();
        Task<List<DropdownListDto1>> GetJobDDLList(string itemText);
        Task<List<DropdownListDto1>> GetStyleDDLList(string itemText);
        Task<List<DropdownListDto1>> GetOrderDDLList(string itemText);

        Task<List<DropdownListDto1>> GetTypeDDLList();
        Task<List<DropdownListDto1>> GetFabricationDDLList(string itemText);
        Task<List<DropdownListDto1>> GetGSMDDLList(string itemText);
        Task<List<DropdownListDto1>> GetDressPartDDLList(string itemText);
        Task<List<DropdownListDto1>> GetUOMDDLList(string itemText);
        Task<List<DropdownListDto1>> GetTrackingNoDDLList(string itemText);

        Task<List<TrackingNoWiseReceiveDto>> GetReceiveDataList(string trackingNo);
        Task<List<TrackingNoWiseReceiveDto>> GetReceiveDataListBatchNo(string batchNo);

        Task<List<DropdownListDto1>> GetTypeOfInspectionDDLList();

       
       Task<Result> SaveTrackingReceive(SaveTrackingNoReceive dto);
        Task<List<TrackingNoWiseReceiveDto>> GetDataBySearchForEditService(int unitId, string receiveNo, string fromDate, string toDate);
        Task<List<DropdownListDto1>> GetJobDDLListData(int unitId, int buyerId);
        Task<List<DropdownListDto1>> GetStyleDDLListData(int unitId, int buyerId, int jobId);
        Task<List<DropdownListDto1>> GetOrderDDLListData(int unitId, int buyerId, int jobId, int styleId);
        Task<List<TrackingNoWiseReceiveDto>> GetBatchPrepareDataList(int unitId, int buyerId, int jobId, int styleId,int orderId);

        Task<List<DropdownListDto1>> GetProcessNameList();
        Task<List<DropdownListDto1>> GetMachineNoList();

        //Task<Result> SaveWashBatchPrepareData(SaveWashBatchPrepareModel saveDataListDto);

       
            Task<Result> SaveWashBatchPrepareData(SaveWashBatchPrepareModel dto);
            Task<Result> SaveWashItemDeliveryData(SaveWashItemDeliveryModel dto);
        Task<List<TrackingNoWiseReceiveDto>> GetWashItemDeliveryList(int unitId, string fromDate, string toDate, string trackingBatchNo);

    }
}
