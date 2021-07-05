using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingEventMVC.Data.Entities
{
   public class EventInvitation
    {
        public int Event_id { get; set; }
        public int User_id { get; set; }
        [Key]
        public int Id { get; set; }

    }
}
