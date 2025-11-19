using Erp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Erp.Domain.Entities.MenuPermission
{
    public class SecurityMenuPermisionModel
    {
        [Table("SC_MENUS")]
        public class SecurityMenuModel : AuditableEntity
        {
            [Column("ID")]
            public int Id { get; set; }

            [Column("MENU_NAME")]
            public string MenuName { get; set; }

            [Column("PARENT_ID")]
            public int ParentId { get; set; }

            [Column("ACTIVE_STATUS")]
            public int ActiveStatus { get; set; }

            [Column("SORT_ORDER")]
            public int SortOrder { get; set; }
            [Column("URL")]
            public string Url { get; set; }

            [Column("REMARKS")]
            public string Remarks { get; set; }

            [Column("ICON")]
            public string Icon { get; set; }
            [Column("TYPE")]
            public string Type { get; set; }


        }
    }
}
