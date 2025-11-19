using System;
using System.Collections.Generic;
using System.Text;
using Erp.Application.Common.Models;
using MediatR;

namespace Erp.Application.Auth.Commands
{
    public class DeleteUser : IRequest<Result>
    {
        public int Id { get; set; }


        public DeleteUser(int id)
        {

            Id = id;
        }

    }
}
