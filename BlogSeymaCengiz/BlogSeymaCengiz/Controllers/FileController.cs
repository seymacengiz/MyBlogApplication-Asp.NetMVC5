﻿using BlogSeymaCengiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSeymaCengiz.Controllers
{
    
    public class FileController : Controller
    {
        private PostArticleDbContext db = new PostArticleDbContext();
        // GET: File
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.Files.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}