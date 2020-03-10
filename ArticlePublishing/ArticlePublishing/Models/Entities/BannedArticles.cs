using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArticlePublishing.Models.Entities
{
    [Table("BannedArticle")]
    public class BannedArticles
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(500)]
        public string Reason { get; set; }
        public DateTime BannedDate { get; set; }
        public int BannedLimit { get; set; }
        public int? ArticleID { get; set; }
        public int? ComplaintID { get; set; }
        public int? AdminListID { get; set; }

        //foreign
        public virtual Articles Article { get; set; }
        public virtual Complaints Complaint { get; set; }
        public virtual AdminList AdminList { get; set; }
    }
}
