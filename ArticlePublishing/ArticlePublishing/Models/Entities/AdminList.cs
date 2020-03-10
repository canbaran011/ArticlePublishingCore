using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArticlePublishing.Models.Entities
{
    [Table("AdminList")]
    public class AdminList
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public int AuthDegree { get; set; }
        [Required]
        public string AuthName { get; set; }
        public int? UserID { get; set; }

        //foreign
        public virtual Users User { get; set; }
        public virtual List<BannedArticles> BannedArticles { get; set; }
        public virtual List<BannedUsers> BannedUsers { get; set; }
    }
}
