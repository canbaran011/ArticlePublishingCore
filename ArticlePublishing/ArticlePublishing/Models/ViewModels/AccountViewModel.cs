using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticlePublishing.Models.ViewModels
{
    public class AccountViewModel
    {
        public int? ID { get; set; }
        public string OldPassword { get; set; }
        public string Password1 { get; set; }
        public string Password2 { get; set; }
    }
}
