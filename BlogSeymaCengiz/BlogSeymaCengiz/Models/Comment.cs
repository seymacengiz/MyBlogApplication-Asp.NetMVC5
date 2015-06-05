using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSeymaCengiz.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
  
        [Required(ErrorMessage = "Please enter your comment.")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Please enter the date of your comment.")]
        [DataType(DataType.DateTime, ErrorMessage = "Please enter the date of your comment correctly.")]
        public DateTime ReleaseTime { get; set; }
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
 
    }
}