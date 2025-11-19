using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Erp.Application.Requests.ErpApp.Helper.Country;
using MediatR;

namespace Erp.Application.Requests.ErpApp.Country.Query
{
    public class GetCountryList: IRequest<IList<CountryDto>>
    {
        public class CountryHandler : IRequestHandler<GetCountryList, IList<CountryDto>>
        {
            private readonly ICountryService _countryService;
            private readonly IMapper _mapper;

            public CountryHandler(ICountryService countryService, IMapper mapper)
            {
                _countryService = countryService;
                _mapper = mapper;
            }

            public async Task<IList<CountryDto>> Handle(GetCountryList request, CancellationToken cancellationToken)
            {
                var countries = await _countryService.GetAllCountry();

                return _mapper.Map<IList<CountryDto>>(countries);
            }
        }
    }
}
