using ArticlePublishing.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticlePublishing.Models.ViewModels
{
    public class NavbarViewModel
    {
        public List<Categories> Categori { get; set; }
        public bool admin { get; set; }
    }
}
