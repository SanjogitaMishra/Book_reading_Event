
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingEventMVC.Data.Entities
{
   public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public int UserId { get; set; }

        public int? EventsId { get; set; }

        public string Email { get; set; }

        public string UserComments { get; set; }
        //[ForeignKey("UserId")]
        public virtual User User { get; set; }

        //[ForeignKey("EventsId")]
        public virtual Event Event { get; set; }
    }
}
