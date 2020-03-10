using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArticlePublishing.Models.Entities
{
    [Table("Comments")]
    public class Comments
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(1000)]
        public string Text { get; set; }
        public DateTime? CommentDate { get; set; }
        public int? UserID { get; set; }
        public int? ArticleID { get; set; }


        //foreign
        public virtual Users User { get; set; }
        public virtual Articles Article { get; set; }
    }
}
