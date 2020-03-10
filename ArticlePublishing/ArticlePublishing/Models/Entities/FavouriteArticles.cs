using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArticlePublishing.Models.Entities
{
    [Table("FavouriteArticles")]
    public class FavouriteArticles
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? UserID { get; set; }
        public int? ArticleID { get; set; }
        public bool Liked { get; set; }
        public bool Favourite { get; set; }

        //foreign
        public virtual Users User { get; set; }
        public virtual Articles Article { get; set; }

    }
}
