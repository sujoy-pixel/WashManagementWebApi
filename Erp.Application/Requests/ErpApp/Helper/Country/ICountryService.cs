using Erp.Application.Common.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Application.Requests.ErpApp.Helper.Country
{
    public interface ICountryService
    {
        Task<IList> GetAllCountry();
      
        Task<List<CountryDto>> BuyerWiseGetAllCountry(int buyerId);
    }
}
