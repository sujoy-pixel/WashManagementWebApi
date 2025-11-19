using System;
using System.Collections.Generic;
using System.Text;

namespace Erp.Domain.Entities.Base
{
    public interface IEntityBase<TId>
    {
        TId Id { get; }
    }
}
