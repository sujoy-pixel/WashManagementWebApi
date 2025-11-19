using Erp.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Requests.ErpApp.Merchandising.Helper.Command
{
    public class CreateBuyerDepartment:IRequest<Result>
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string ContactPerson { get; set; }

        public string MobileNo { get; set; }

        public string Email { get; set; }

        public int BuyerId { get; set; }

        public string Category { get; set; }
    }
}
