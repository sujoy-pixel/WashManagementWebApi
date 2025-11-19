using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Application.Auth.Query
{
    public class GetRandomToken : IRequest<int>
    {
        public string EmpCode { get; set; }
        public string TokenNumber { get; set; }
        public GetRandomToken(string empCode, string tokenNumber)
        {
            EmpCode = empCode;
            TokenNumber = tokenNumber;

        }
    }
}
