using Erp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Erp.Domain.Entities.MenuPermission
{
    [Table("BUYERS_USERS")]
    public class BuyersUsers:AuditableEntity
    {
        
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("USER_ID")]
        public int UserId { get; set; }
        [Column("BUYER_ID")]
        public int BuyerId { get; set; }
        [Column("REMARKS")]
        public string Remarks { get; set; }
       
    }
}
