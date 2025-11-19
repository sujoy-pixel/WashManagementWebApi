using Erp.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Requests.ErpApp.Helper.BuyerSizeSet.Command
{
    public class CreateBuyerSizeSet:IRequest<Result>
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public string SizeRange { get; set; }
    }
}
