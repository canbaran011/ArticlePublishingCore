using ArticlePublishing.Models.Entities;
using ArticlePublishing.Models.Entities.Manager;
using ArticlePublishing.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticlePublishing.Models.ViewComponents
{
    public class NavbarViewComponent:ViewComponent
    {
        DatabaseContext db;
        public NavbarViewComponent(DatabaseContext context)
        {
            db = context;
        }
        public IViewComponentResult Invoke()
        {
            int? sId= HttpContext.Session.GetInt32("ID");
            ViewModels.NavbarViewModel model = new ViewModels.NavbarViewModel();
            model.Categori = db.Categories.ToList();
            if (sId!= null)
            {
                AdminList adminlist = new AdminList();
                adminlist = db.AdminList.Where(x => x.UserID == sId).FirstOrDefault();
                if (adminlist != null)
                {
                    model.admin = true;
                }
            }
            return View(model);
        }
    }
}
