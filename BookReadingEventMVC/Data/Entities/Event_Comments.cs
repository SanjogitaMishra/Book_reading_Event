using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingEventMVC.Data.Entities
{
   public class Event_Comments
    {
        [Key]
        public int Id { get; set; }

        public int Event_id { get; set; }
        public String Comments { get; set; }
    }
}
