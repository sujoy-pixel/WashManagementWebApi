using Erp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Erp.Domain.Entities.MenuPermission
{
    [Table("MENU_MAIN")]
    public class MenuMainModel:AuditableEntity
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("MENU_NAME")]
        public string MenuName { get; set; }

        [Column("ACTIVE_STATUS")]
        public bool ActiveStatus { get; set; }

        [Column("SORT_ORDER")]
        public int SortOrder { get; set; }

        [Column("URL")]
        public string Url { get; set; }

    }
}
