using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticlePublishing.Models.Entities.Manager
{
    public class DbInitialize
    {
        public static void InitializeDb(IApplicationBuilder app)
        {
            DatabaseContext context = app.ApplicationServices.GetRequiredService<DatabaseContext>();
            context.Database.Migrate();
            /*burada yazılacak kodlar baslangıc verilerini olusturacak*/

            if (context.Users.Any() == false)
            {

                for (int i = 0; i < 10; i++)
                {
                    Users user = new Users();
                    user.Name = FakeData.NameData.GetFirstName();
                    user.Surname = FakeData.NameData.GetSurname();
                    user.Email = FakeData.NetworkData.GetEmail();
                    user.Adress = FakeData.PlaceData.GetAddress();
                    user.Phone = "553 510 1122";
                    user.Password = "AEsnGm/7BfPmlrcMzygzzxTWLlM1Faikyhj3Z8mTaytVPV6giPYWJiISEGAE0FpAfw==";//123
                    user.UserName = FakeData.NameData.GetCompanyName();
                    user.ProfileImage = "05635dabf9b0453cb0b147848c0b3b27.jpg";
                    user.BannedStatus = FakeData.BooleanData.GetBoolean();
                    user.AccountStatus = FakeData.BooleanData.GetBoolean();
                    user.RegisterDate = DateTime.Now;
                    user.LastActiveDate = DateTime.Now;
                    context.Users.Add(user);
                }
                context.SaveChanges();
                for (int i = 0; i < 10; i++)
                {
                    Categories categories = new Categories();
                    categories.CategoriName = FakeData.PlaceData.GetCountry();
                    context.Categories.Add(categories);
                }

                context.SaveChanges();
                for (int i = 0; i < 3; i++)
                {
                    BannedUsers bannedUsers = new BannedUsers();
                    bannedUsers.BannedDate = DateTime.Now;
                    bannedUsers.AdminListID = 1;
                    bannedUsers.BannedLimit = DateTime.Today;
                    bannedUsers.Reason = FakeData.TextData.GetSentence();
                }

                context.SaveChanges();
                List<Users> users = context.Users.ToList();
                List<Categories> kategori = context.Categories.ToList();

                for (int i = 0; i < 3; i++)
                {
                    AdminList admin = new AdminList();
                    admin.User = users[i];
                    admin.AuthDegree = 2;
                    admin.AuthName = "Admin";
                    context.AdminList.Add(admin);
                }
                foreach (Users user in users)
                {
                    for (int i = 0; i < FakeData.NumberData.GetNumber(1, 5); i++)
                    {
                        Articles article = new Articles();
                        //try
                        //{
                        article.User = user;
                        article.Category = kategori[i];
                        article.Title = FakeData.TextData.GetSentence();
                        article.Text = FakeData.TextData.GetSentences(2);
                        article.DefaultImage = "bc06537e49814c258bd0b6d738a1e792.jpg";
                        article.AddDate = FakeData.DateTimeData.GetDatetime();
                        article.UpdateDate = FakeData.DateTimeData.GetDatetime();
                        article.NumOfLikes = FakeData.NumberData.GetNumber(1, 10000);
                        article.BannedStatus = FakeData.BooleanData.GetBoolean();
                        article.ArticleStatus = FakeData.BooleanData.GetBoolean();
                        context.Articles.Add(article);
                        context.SaveChanges();
                        //}
                        //catch (DbEntityValidationException e)
                        //{
                        //    foreach (var eve in e.EntityValidationErrors)//faydalı bir kod 1 saat  sonunda sorunu bulmamı sağladı :D
                        //    {
                        //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        //        foreach (var ve in eve.ValidationErrors)
                        //        {
                        //            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                        //                ve.PropertyName, ve.ErrorMessage);
                        //        }
                        //    }
                        //    throw;
                        //}
                        for (int t = 0; t < 10; t++)
                        {
                            ArticleImages articleImages = new ArticleImages();
                            articleImages.Article = article;
                            articleImages.ImagesPath = "bc06537e49814c258bd0b6d738a1e792.jpg";
                            context.ArticleImages.Add(articleImages);
                            Comments comments = new Comments();
                            comments.Article = article;
                            comments.User = user;
                            comments.CommentDate = DateTime.Now;
                            comments.Text = FakeData.TextData.GetSentence();
                            context.Comments.Add(comments);
                        }
                    }
                }
                context.SaveChanges();

            }
        }
    }
}
