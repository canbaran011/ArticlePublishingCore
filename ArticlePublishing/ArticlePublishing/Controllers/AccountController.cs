using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticlePublishing.Models.Entities;
using ArticlePublishing.Models.Entities.Manager;
using ArticlePublishing.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ArticlePublishing.Controllers
{
    public class AccountController : Controller
    {
        DatabaseContext db;
        private readonly IHostingEnvironment hostingEnvironment;
        public AccountController(DatabaseContext context, IHostingEnvironment environment)
        {
            db = context;
            hostingEnvironment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserInformation(int? id)
        {
            int? sId = HttpContext.Session.GetInt32("ID");
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == sId)
            {
                return RedirectToAction("Profiles", "Account");
            }
            Users model = new Users();
            model = db.Users.Where(x => x.ID == id).FirstOrDefault();
            return View(model);
        }
        public IActionResult UserArticles(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ArticleViewModel articles = new ArticleViewModel();
            articles.articlesList = db.Articles.Where(x => x.UserID == id && x.ArticleStatus == true).ToList();
            return View(articles);
        }
        public IActionResult UserFavouriteArticles(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Articles> blogList = new List<Articles>();
            List<FavouriteArticles> liked = db.FavouriteArticles.Where(x => x.UserID == id).ToList();
            foreach (FavouriteArticles item in liked)
            {
                Articles b = new Articles();
                b = db.Articles.Where(x => x.ID == item.ArticleID).FirstOrDefault();
                blogList.Add(b);
            }
            ArticleViewModel model = new ArticleViewModel();
            model.articlesList = blogList;
            return View(model);
        }
        public IActionResult Profiles()
        {
            int? sId = HttpContext.Session.GetInt32("ID");
            if (sId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult DeleteAccount()
        {
            int? sId = HttpContext.Session.GetInt32("ID");
            Users user = db.Users.Where(x => x.ID == sId).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public IActionResult DeleteAccount(Users s)
        {
            int? sId = HttpContext.Session.GetInt32("ID");
            Users user = db.Users.Where(x => x.ID == sId).FirstOrDefault();
            user.AccountStatus = false;
            db.SaveChanges();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.ForgotPass = TempData["ForgotPassword"];
            return View();
        }

        [HttpPost]
        public IActionResult Login(Users model)
        {
            Users user = new Users();
            bool password = false;
            user = db.Users.Where(x => (x.Email == model.Email || x.UserName == model.Email) && x.AccountStatus != false).FirstOrDefault();
            if (user != null)
            {
                if (user.Password == model.Password)
                {
                    password = true;
                }
                else
                {
                    password = false;
                }
                //    password = Crypto.VerifyHashedPassword(user.Password, model.Password);
            }

            if (user != null)//üye bulunduysa
            {
                if (user.BannedStatus == true)
                {
                    ViewBag.Warning = "You are banned.";
                    ViewBag.Status = "danger";
                    return View();
                }
                if (password != false)
                {
                    AdminList admin = db.AdminList.Where(x => x.User.ID == user.ID).FirstOrDefault();
                    if (admin == null)
                    {
                        HttpContext.Session.SetString("USER", user.UserName);//üye yönetici değil ise
                        HttpContext.Session.SetInt32("ID", user.ID);
                    }
                    else
                    {
                        HttpContext.Session.SetString("USER", user.UserName + "(" + admin.AuthName + ")");
                        HttpContext.Session.SetInt32("ID", user.ID);

                    }
                    user.LastActiveDate = DateTime.Now;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Warning = "Wrong password.Try again...";
                    ViewBag.Status = "danger";
                }
            }
            else
            {
                ViewBag.Warning = "Email/User name not found.";
                ViewBag.Status = "danger";
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Users model, IFormFile file)
        {
            Users user = new Users();
            Users username = new Users();
            user = db.Users.Where(x => x.Email == model.Email).FirstOrDefault();
            username = db.Users.Where(x => x.UserName == model.UserName).FirstOrDefault();
            if (user != null)
            {
                ViewBag.Warning = "This Email has already taken.";
                ViewBag.Status = "danger";
                return View();
            }
            else if (username != null)
            {
                ViewBag.Warning = "This User name has already taken.";
                ViewBag.Status = "danger";
                return View();
            }
            else
            {
                bool digit = model.Password.Any(Char.IsDigit);//password enaz 1 sayı ve 1 karakter içermesi için kontrol
                bool letter = model.Password.Any(Char.IsLetter);

                if (model.Password.Length < 8 || !digit || !letter)//ters mantık kullanıldı
                {
                    ViewBag.Warning = "Create your password with at least 8 characters, at least 1 number and 1 digit.";
                    ViewBag.Status = "danger";
                    return View();
                }
                else
                {
                    #region mail gönderme

                    SmtpClient smtp = new SmtpClient();//gideceği yer server
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;

                    NetworkCredential auth = new NetworkCredential();//nasıl gidecek
                    auth.UserName = "infoprojects01@gmail.com";
                    auth.Password = "Aa123456*";
                    smtp.Credentials = auth;
                    //buraya kadar ayarlar yapıldı alt yapı hazırlandı
                    MailMessage msg = new MailMessage();
                    msg.Subject = "Account Information";
                    msg.Body = @"<strong> Email: [email] </strong><br/>".Replace("[email]", model.Email);
                    msg.Body += @"<strong> Password: [password] </strong><br/>".Replace("[password]", model.Password);
                    msg.Body += @"<strong> Username and password created successfully. </strong><br/>";
                    msg.IsBodyHtml = true;//body içerisinde yazılan html tagları aktif hale getiriyor
                    msg.To.Add(model.Email);//mailin gideceği adres
                    msg.From = new MailAddress("infoprojects01@gmail.com", "Article Publishing and Discussion Platform");

                    try
                    {
                        smtp.Send(msg);
                    }
                    catch (Exception)
                    {
                        ViewBag.Warning = "Please enter a valid e-mail.";
                        ViewBag.Status = "danger";
                        return RedirectToAction("Register", "Account");
                    }
                    #endregion

                    #region password hashing
                    //string password = Crypto.HashPassword(model.Password);
                    string password = model.Password;
                    #endregion
                    try
                    {
                        string fileName = "05635dabf9b0453cb0b147848c0b3b27.jpg";
                        if (file != null)
                        {
                            var uniqueFileName = GetUniqueFileName(file.FileName);//benzersiz dosya ismi olusturuldu.
                            var images = Path.Combine(hostingEnvironment.WebRootPath, "Images");//wwwroot klasorune kadarki yol alınıp images ile birleştirildi
                            var filePath = Path.Combine(images, uniqueFileName);//dosya yolu ve adı birşetirildi.
                            file.CopyTo(new FileStream(filePath, FileMode.Create));
                            fileName = uniqueFileName;
                        }
                        #region database kayıt işlemleri
                        user = new Users();
                        user.Name = model.Name;
                        user.Surname = model.Surname;
                        user.Email = model.Email;
                        user.UserName = model.UserName;
                        user.Password = password;
                        user.Adress = model.Adress;
                        user.Phone = model.Phone;
                        user.ProfileImage = fileName;
                        user.AccountStatus = true;
                        user.BannedStatus = false;
                        user.RegisterDate = DateTime.Now;
                        user.LastActiveDate = DateTime.Now;
                        db.Users.Add(user);
                        db.SaveChanges();
                        #endregion

                        HttpContext.Session.SetString("USER", user.UserName);
                        user = db.Users.Where(x => x.Email == user.Email).FirstOrDefault();
                        HttpContext.Session.SetInt32("ID", user.ID);
                    }
                    catch (Exception)
                    {
                        return RedirectToAction("Login", "Account");
                    }

                    return RedirectToAction("Index", "Home");
                }
            }
        }
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
        public IActionResult UpdateInformation()
        {
            int? sId = HttpContext.Session.GetInt32("ID");
            if (sId == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                Users user;
                user = db.Users.Where(x => x.ID == sId).FirstOrDefault();
                return View(user);
            }
        }

        [HttpPost]
        public IActionResult UpdateInformation(Users model, IFormFile file)
        {
            int? sId = HttpContext.Session.GetInt32("ID");
            Users user = new Users();
            bool record = false;
            user = db.Users.Where(x => x.ID == sId).FirstOrDefault();
            Users userMailchk = db.Users.Where(x => x.Email == model.Email).FirstOrDefault();
            Users userUserNamechk = db.Users.Where(x => x.UserName == model.UserName).FirstOrDefault();
            //email adresi ve kullanıcı adı tabloda 
            //eğer girilen mail adresi tabloda varsa ve idler aynı ise mail adresi güncellenmek istenmiyordur devam edilebilir kayıt için. veya girilen mail adresi veritabanında bulunamamıştır yine kayıt için yeterli koşulu sağlar. null referans hatası verdiği için şartları uzunca yazmam gerekiyor. tek if içerisinde null gelirse id ler karşılaştırılamıyor ve hata veriyor.
            if ((userMailchk.Email == null))//veritanında bulunamadıysa
            {
                //nickname yada e mail in null olması yukarıdaki sorgularda bulunamamsı demek.
                if ((userUserNamechk == null))//aynı mantık
                {
                    record = true;//kullanıcı adı ve email kullanımda değil kayıt edilebilir.
                }
                else //boş değilse kendimi kullanıyor başkası mı, kontrol ediliyor
                {
                    if (userUserNamechk.ID == sId)//kendisi kullanıyor diğer bilgilerde kayıt edilebilir
                    {
                        record = true;
                    }
                    else
                    {
                        record = false;
                        ViewBag.Warning = "The username is currently in use";
                        ViewBag.Status = "danger";
                    }
                }
            }
            else if (userMailchk.Email != null)//aynı mantık mail kullanımda
            {
                if (userMailchk.ID == sId)//maili kendi mi kullanıyor
                {
                    if (userUserNamechk == null)//mail kendine ait ise girdiği user name tablo da var, mı kullanımda mı?
                    {
                        record = true;

                    }
                    else//kullanıcı adı boşta ise kayıt yapılabilir
                    {
                        if (userUserNamechk.ID == sId)//var ise kendine mi ait
                        {
                            record = true;
                        }
                        else//kendine iat değilse başkası tarafından kullanılıyordur ekrana hata ver
                        {
                            record = false;
                            ViewBag.Warning = "The username is currently in use";
                            ViewBag.Status = "danger";
                        }
                    }
                }
                else //mail kullanılıyor ve kendisi değil ise
                {
                    record = false;
                    ViewBag.Warning = "The e-mail address is currently in use.";
                    ViewBag.Status = "danger";

                }
            }


            if (record)
            {
                if (file != null)
                {
                    var uniqueFileName = GetUniqueFileName(file.FileName);
                    var images = Path.Combine(hostingEnvironment.WebRootPath, "Images");//dosya yolunun bulunması için
                    var filePath = Path.Combine(images, uniqueFileName);
                    file.CopyTo(new FileStream(filePath, FileMode.Create));
                    user.ProfileImage = uniqueFileName;
                }
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.Adress = model.Adress;
                user.Phone = model.Phone;
                db.SaveChanges();
                ViewBag.Warning = "Your information updated successfully.";
                ViewBag.Status = "success";
                AdminList admin = new AdminList();
                admin = db.AdminList.Where(x => x.ID == sId).FirstOrDefault();
                if (admin != null)
                {
                    HttpContext.Session.SetString("USER", user.UserName + "(" + admin.AuthName + ")");
                }
                else
                {
                    HttpContext.Session.SetString("USER", user.UserName);
                }

            }

            /*
             * Devamı gelecek
             * Email adresi kontrolü yapılacak
             */
            /*
            #region mail gönderme

            SmtpClient smtp = new SmtpClient();//gideceği yer server
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential auth = new NetworkCredential();//nasıl gidecek
            auth.UserName = "infoprojects01@gmail.com";
            auth.Password = "Aa123456*";
            smtp.Credentials = auth;
            //buraya kadar ayarlar yapıldı alt yapı hazırlandı
            MailMessage msg = new MailMessage();
            msg.Subject = "Blog Sayfasına Kayıt";
            msg.Body = @"<strong> Email: [email] </strong><br/>".Replace("[email]", model.Email);
            msg.Body += @"<strong> Password: [password] </strong><br/>".Replace("[password]", model.Password);
            msg.Body += @"<strong> Kullanici adiniz ve sifreniz basariyla olusturulmustur. </strong><br/>";
            msg.IsBodyHtml = true;//body içerisinde yazılan html tagları aktif hale getiriyor
            msg.To.Add(model.Email);//mailin gideceği adres
            msg.From = new MailAddress("infoprojects01@gmail.com", "Blog Üyelik Bilgileri");

            try
            {
                smtp.Send(msg);
            }
            catch (Exception)
            {
                ViewBag.Warning = "Lütfen geçerli bir Email adresi girin.";
                ViewBag.Status = "danger";
                return RedirectToAction("Register", "Account");
            }
            #endregion
            */

            return View();
        }

        public IActionResult ChangePassword()
        {
            if (HttpContext.Session.GetString("USER") == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(AccountViewModel model)
        {
            model.ID = HttpContext.Session.GetInt32("ID");
            Users user = new Users();
            user = db.Users.Where(x => x.ID == model.ID).FirstOrDefault();
            //bool password;
            if (user != null)
            {
                //password = Crypto.VerifyHashedPassword(user.Password, model.OldPassword);//kullanıcının girdiği passwordle veritabanındakini karşılaştırıyor.
                if (user.Password != model.OldPassword)
                {
                    ViewBag.Warning = "Old password is wrong.";
                    ViewBag.Status = "danger";
                    return View();
                }
                int result = string.Compare(model.Password1, model.Password2);
                if (result == 0)
                {
                    bool digit = model.Password1.Any(Char.IsDigit);//password enaz 1 sayı ve 1 karakter içermesi için kontrol
                    bool letter = model.Password1.Any(Char.IsLetter);//pass2 yi kontrol etmedim çünkü üstte ikisi aynıysa bu alana girecek

                    if (model.Password1.Length < 8 || !digit || !letter)//ters mantık kullanıldı
                    {
                        ViewBag.Warning = "Güvenliğiniz için parolanızı en az 8 karakter, en az 1 sayı ve 1 rakam içerecek şekilde oluşturun.";
                        ViewBag.Status = "danger";
                        return View();
                    }
                    else
                    {
                        //user.Password = Crypto.HashPassword(model.Password1);
                        user.Password = model.Password1;
                        db.SaveChanges();
                        ViewBag.Warning = "Şifreniz başarıyla değiştirilmiştir.";
                        ViewBag.Status = "success";
                    }
                }
                else
                {
                    ViewBag.Warning = "Girdiğiniz şifreler aynı değil.";
                    ViewBag.Status = "danger";
                }
            }
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(Users model)
        {
            Users user = new Users();
            user = db.Users.Where(x => x.Email == model.Email || x.UserName == model.Email || x.Phone == model.Email).FirstOrDefault();
            if (user != null)
            {
                #region sifre olusturma
                int count = 10;
                const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                StringBuilder res = new StringBuilder();
                Random rnd = new Random();
                while (0 < count)
                {
                    res.Append(valid[rnd.Next(valid.Length)]);
                    count--;
                }

                string newPassword = res.ToString();

                #endregion
                #region Mail ayarları
                SmtpClient smtp = new SmtpClient();//gideceği yer
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;

                NetworkCredential auth = new NetworkCredential();//nasıl gidecek
                auth.UserName = "infoprojects01@gmail.com";
                auth.Password = "Aa123456*";
                smtp.Credentials = auth;
                //buraya kadar ayarlar yapıldı alt yapı hazırlandı
                MailMessage msg = new MailMessage();
                msg.Subject = "New Password";
                //msg.Body = txtMesaj.Text;
                msg.Body = @"<strong> Email: [email] </strong><br/>".Replace("[email]", user.Email);
                msg.Body += "<strong> New Password: [sifre] </strong><br/>".Replace("[sifre]", newPassword);
                msg.IsBodyHtml = true;//body içerisinde yazılan html tagları aktif hale getiriyor
                msg.To.Add(user.Email);
                msg.From = new MailAddress("infoprojects01@gmail.com", "Create Password");
                #endregion
                try
                {
                    smtp.Send(msg);

                    //string CryptoSifre = Crypto.HashPassword(newPassword);
                    user.Password = newPassword;
                    //db.Users.Attach(user);
                    //db.Entry(user).State=System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.Warning = "Your password has been created successfully.Please check your e-mail.";
                    ViewBag.Status = "success";


                }
                catch (Exception)
                {
                    ViewBag.Warning = "An error occurred during the update. Please try again.";
                    ViewBag.Status = "danger";
                }

                TempData["ForgotPassword"] = "Your password has been created successfully.Please check your e-mail.";

                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.Warning = "A registered e-mail address, or userName was not found. Please try again.";
                ViewBag.Status = "danger";
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}