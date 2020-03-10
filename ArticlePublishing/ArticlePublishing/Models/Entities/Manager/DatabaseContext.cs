using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticlePublishing.Models.Entities.Manager
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options) 
        {
            
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<ArticleImages> ArticleImages { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<AdminList> AdminList { get; set; }
        public DbSet<Complaints> Complaints { get; set; }
        public DbSet<FavouriteArticles> FavouriteArticles { get; set; }
        public DbSet<BannedArticles> BannedArticles { get; set; }
        public DbSet<BannedUsers> BannedUsers { get; set; }
    }
}
