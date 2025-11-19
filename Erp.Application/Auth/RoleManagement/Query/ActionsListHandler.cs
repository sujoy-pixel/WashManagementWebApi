using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Erp.Application.Auth.RoleManagement.Query
{
    public class ActionsListHandler : IRequestHandler<ActionsList, List<ActionsDto>>
    {
        private readonly IActions _actions;
        public ActionsListHandler(IActions actions)
        {
            _actions = actions;
        }
        public async Task<List<ActionsDto>> Handle(ActionsList request, CancellationToken cancellationToken)
        {
            var res = await _actions.GetAllActions();
            return res;
        }
    }
}
