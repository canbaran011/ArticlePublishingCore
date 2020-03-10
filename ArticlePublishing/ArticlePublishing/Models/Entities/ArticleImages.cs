using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArticlePublishing.Models.Entities
{
    [Table("ArticleImages")]
    public class ArticleImages
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [StringLength(250), Required]
        public string ImagesPath { get; set; }
        public int? ArticleID { get; set; }

        //foreign
        public virtual Articles Article { get; set; }
    }
}
