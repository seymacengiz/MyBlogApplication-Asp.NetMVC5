using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PagedList;

namespace BlogSeymaCengiz.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
   
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter the content of article.")]
       
        public string Content { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateTime { get; set; }

        public string Author { get; set; }
        public virtual ICollection<File> Files { get; set; } 

        //Bir makalede, birden çok yorum bulunabilir.
        public virtual List<Comment> Comments { get; set; }
    }
    public class PostArticleDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Comment> Comments { get; set; }
      
    }
}