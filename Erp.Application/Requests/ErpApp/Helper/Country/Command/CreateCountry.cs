using Erp.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Requests.ErpApp.Helper.Country.Command
{
    public class CreateCountry : IRequest<Result>
    {
        public int ID { get; set; }

        public string CountryName { get; set; }

    }
}
