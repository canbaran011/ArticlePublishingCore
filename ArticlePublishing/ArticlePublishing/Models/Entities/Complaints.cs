using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArticlePublishing.Models.Entities
{
    [Table("Complaints")]
    public class Complaints
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(50)]
        public string Subject { get; set; }
        [StringLength(500)]
        public string Text { get; set; }
        public int? UserID { get; set; }
        public int? ArticleID { get; set; }
        public bool Checked { get; set; }

        //foreign
        public virtual Users User { get; set; }
        public virtual Articles Article { get; set; }
        public virtual List<BannedArticles> BannedArticles { get; set; }
    }
}
