using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArticlePublishing.Models.Entities
{
    [Table("BannedUsers")]
    public class BannedUsers
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(500)]
        public string Reason { get; set; }
        public DateTime? BannedDate { get; set; }
        public DateTime? BannedLimit { get; set; }
        public int? UserID { get; set; }
        public int? AdminListID { get; set; }

        //foreign
        public virtual Users User { get; set; }
        public virtual AdminList AdminList { get; set; }
    }
}
