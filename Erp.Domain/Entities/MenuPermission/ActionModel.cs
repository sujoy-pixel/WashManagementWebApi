using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Erp.Domain.Entities.MenuPermission
{
    [Table("ACTIONS_LIST")]
    public class ActionModel
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("ACTION_NAME")]
        public string ActionName { get; set; }
    }
}
