using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingEventMVC.Models.ViewModels
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }

        public int UserId { get; set; }

        public int EventsId { get; set; }

        public string Email { get; set; }

        public string UserComments { get; set; }
    }
}
