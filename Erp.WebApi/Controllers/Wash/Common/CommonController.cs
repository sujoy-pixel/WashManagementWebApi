

using Erp.Application.Commercial.Setup.Command;
using Erp.Application.MascoWash.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Erp.WebApi.Controllers.Commercial.Common
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CommonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ActionName("GetUnitName")]
        public async Task<IActionResult> GetUnitName()
        {
            return Ok(await _mediator.Send(new UnitNameGet()));
        }
       

        [HttpGet]
        [ActionName("GetFaultHead")]
        public async Task<IActionResult> GetFaultHead()
        {
            return Ok(await _mediator.Send(new FaultHeadDDL()));
        }

        [HttpGet]
        [ActionName("GetInspectionHeadDDL")]
        public async Task<IActionResult> GetInspectionHeadDDL()
        {
            return Ok(await _mediator.Send(new InspectionHeadDDL()));
        }
        [HttpGet]
        [ActionName("GetFaultHeadDDL")]
        public async Task<IActionResult> GetFaultHeadDDL()
        {
            return Ok(await _mediator.Send(new FaultHeadDDL()));
        }

        [HttpGet]
        [ActionName("GetOperationNameDDL")]
        public async Task<IActionResult> GetOperationNameDDL()
        {
            return Ok(await _mediator.Send(new OperationNameDDL()));
        }

        [HttpGet]
        [ActionName("GetBuyerDDL")]
        public async Task<IActionResult> GetBuyerDDL()
        {
            return Ok(await _mediator.Send(new BuyerDDL()));
        }

        [HttpGet]
        [ActionName("GetJobDDL")]
        public async Task<IActionResult> GetJobDDL(string itemText)
        {

            return Ok(await _mediator.Send(new JobDDL(itemText)));
        }


        [HttpGet]
        [ActionName("GetStyleDDL")]
        public async Task<IActionResult> GetStyleDDL(string itemText)
        {
            return Ok(await _mediator.Send(new StyleDDL(itemText)));
        }

        [HttpGet]
        [ActionName("GetOrderDDL")]
        public async Task<IActionResult> GetOrderDDL(string itemText)
        {
            return Ok(await _mediator.Send(new OrderDDL(itemText)));
        }

        [HttpGet]
        [ActionName("GetTypeDDL")]
        public async Task<IActionResult> GetTypeDDL()
        {
            return Ok(await _mediator.Send(new TypeDDL()));
        }

        [HttpGet]
        [ActionName("GetFabricationDDL")]
        public async Task<IActionResult> GetFabricationDDL(string itemText)
        {
            return Ok(await _mediator.Send(new FabricationDDL(itemText)));
        }

        [HttpGet]
        [ActionName("GetGSMDDL")]
        public async Task<IActionResult> GetGSMDDL(string itemText)
        {
            return Ok(await _mediator.Send(new GSMDDL(itemText)));
        }

        [HttpGet]
        [ActionName("GetDressPart")]
        public async Task<IActionResult> GetDressPart(string itemText)
        {
            return Ok(await _mediator.Send(new DressPartDDL(itemText)));
        }

        [HttpGet]
        [ActionName("GetUOM")]
        public async Task<IActionResult> GetUOM(string itemText)
        {
            return Ok(await _mediator.Send(new UOMDDL(itemText)));
        }

        [HttpGet]
        [ActionName("GetTrackingNo")]
        public async Task<IActionResult> GetTrackingNo(string itemText)
        {
            return Ok(await _mediator.Send(new TrackingNoDDL(itemText)));
        }

        [HttpGet]
        [ActionName("GetTypeOfInspectionDDL")]
        public async Task<IActionResult> GetTypeOfInspectionDDL()
        {
            return Ok(await _mediator.Send(new TypeOfInspectionDDL()));
        }

      
        [HttpGet]
        [ActionName("GetJobByUnitAndBuyerDDL")]
        public async Task<IActionResult> GetUnitBuyerWiseJob(int unitId,int buyerId)
        {
            var result = await _mediator.Send(
                new JobUnitBuyerDDL(unitId,buyerId)
            );

            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetStyleByUnitBuyerAndJobDDL")]
        public async Task<IActionResult> GetUnitBuyerJobWiseStyle(int unitId,int buyerId,int jobId)
        {
            var result = await _mediator.Send(
                new StyleUnitBuyerJobWiseDDL(unitId,buyerId,jobId)
            );

            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetOrderByUnitBuyerJobAndStyleDDL")]
        public async Task<IActionResult> GetStyleUnitBuyerJobStyleWiseOrder(int unitId, int buyerId, int jobId,int styleId)
        {
            var result = await _mediator.Send(
                new OrderStyleUnitBuyerJobDDL(unitId, buyerId, jobId,styleId)
            );

            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetProcessNameDDL")]
        public async Task<IActionResult> GetProcessNameDDL()
        {
            return Ok(await _mediator.Send(new ProcessNameDDL()));
        }

        [HttpGet]
        [ActionName("GetMachineNoDDL")]
        public async Task<IActionResult> GetMachineNoDDL()
        {
            return Ok(await _mediator.Send(new MachineNoDDL()));
        }

    }
}
