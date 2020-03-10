using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArticlePublishing.Models.Entities
{
    [Table("Articles")]
    public class Articles
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(250), Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string DefaultImage { get; set; }
        public int NumOfLikes { get; set; }
        public bool BannedStatus { get; set; }
        public bool ArticleStatus { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UserID { get; set; }
        public int? CategoryID { get; set; }

        //foreign
        public virtual Users User { get; set; }
        public virtual Categories Category { get; set; }
        public virtual List<FavouriteArticles> FavouriteArticles { get; set; }
        public virtual List<Complaints> Complaints { get; set; }
        //bir çok kez engellenebilir olabileceği için
        public virtual List<BannedArticles> BannedArticles { get; set; }
        public virtual List<ArticleImages> ArticleImages { get; set; }
        public virtual List<Comments> Comments { get; set; }

    }
}
