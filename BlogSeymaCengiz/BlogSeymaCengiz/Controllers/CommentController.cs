using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogSeymaCengiz.Models;

namespace BlogSeymaCengiz.Controllers
{
    public class CommentController : Controller
    {
        private PostArticleDbContext db = new PostArticleDbContext();
        // GET: Comment
        public ActionResult Index()
        {
            return View(db.Comments.ToList());
        }
        // GET: Article/Create
        public ActionResult AddComment()
        {
            return View();
        }

        // POST: Article/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment([Bind(Include = "Content,ReleaseTime")] Comment comment, HttpPostedFileBase upload)
        {
               if (ModelState.IsValid)
                {
                    db.Comments.Add(comment);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
         
            return View(comment);
        }

    }
}