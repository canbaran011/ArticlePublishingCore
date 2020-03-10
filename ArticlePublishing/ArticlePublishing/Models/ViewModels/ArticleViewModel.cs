using ArticlePublishing.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticlePublishing.Models.ViewModels
{
    public class ArticleViewModel
    {
        public List<Articles> articlesList { get; set; }
        public Articles article { get; set; }
        public SelectList categoriSelectList { get; set; }
        public Comments comment { get; set; }
        public Complaints complaints { get; set; }
        public BannedArticles bannedArticles { get; set; }
        public int? userID;
        public FavouriteArticles favouriteArticles { get; set; }
        public bool admin;
        public int? complaintID { get; set; }
    }
}
