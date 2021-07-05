using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookReadingEventMVC.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public int UserId { get; set; }

        public int EventsId { get; set; }
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Can't Add Empty Comments")]
        [MinLength(3)]
        public string UserComments { get; set; }
    }
}