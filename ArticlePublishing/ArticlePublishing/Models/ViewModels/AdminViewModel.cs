using ArticlePublishing.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticlePublishing.Models.ViewModels
{
    public class AdminViewModel
    {
        public List<Users> userList { get; set; }
        public List<Users> useradminList { get; set; }
        public List<Complaints> Complaints { get; set; }
        public List<BannedArticles> bannedBlogsList { get; set; }
        public Users user { get; set; }
        public bool superadmin { get; set; }
    }
}
