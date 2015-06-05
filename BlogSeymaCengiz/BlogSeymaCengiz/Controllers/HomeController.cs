using BlogSeymaCengiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogSeymaCengiz.Models;
using PagedList;
using System.Data.Entity.Infrastructure;

namespace BlogSeymaCengiz.Controllers
{
    public class HomeController : Controller
    {
        private PostArticleDbContext db = new PostArticleDbContext();
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Admin()
        {
            return RedirectToAction("Index","Admin");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //Son 5 makale Resminin ana sayfaya yükleneceği Action
        public ActionResult ArticleDetails(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Include(s => s.Files).SingleOrDefault(s => s.ArticleId == id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }
      
        //Son 5 makalenin ana sayfaya yükleneceği Action
        public ActionResult LastFiveArticle(int? id)
        {
            //Veritabanından yeni bir nesne oluşturuyoruz.
             PostArticleDbContext db = new PostArticleDbContext();
            
            //Veritabanından sorgulamayı Linq ile yapıyoruz.
            //Tarih sırasına göre son makaleleri OrderByDescending ile çekip Take ile de 5 tane almasını istiyoruz.
             
             Article article = db.Articles.Include(s => s.Files).SingleOrDefault(s => s.ArticleId == id);
             List<Article> articleList = db.Articles.OrderByDescending(i => i.DateTime).Take(5).ToList();
           
            //Normal içeriklerde View döndürürken, burada ise PartialView döndürüyoruz.
            //Ayrıca makaleListe nesnesini de View'de kullanacağımız şekilde model olarak aktarıyoruz.
            return PartialView(articleList);
       }
        public ActionResult CommentLastFive()
        {
            //Veritabanından yeni bir nesne oluşturuyoruz.
            PostArticleDbContext db = new PostArticleDbContext();
          
            List<Comment> commentList = db.Comments.OrderByDescending(i => i.ReleaseTime).Take(5).ToList();
            return PartialView(commentList);
        }

        public ActionResult AllArticle(string sortOrder, string searchString, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var artcl = from s in db.Articles select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                artcl = artcl.Where(s => s.Title.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    artcl = artcl.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    artcl = artcl.OrderBy(s => s.DateTime);
                    break;
                case "date_desc":
                    artcl = artcl.OrderByDescending(s => s.DateTime);
                    break;
                default:  // Name ascending 
                    artcl = artcl.OrderBy(s => s.Author);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(artcl.ToPagedList(pageNumber, pageSize));
           
        }
    }
} 