using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookReadingEventMVC.Models
{
    public class Event
    {
        public int EventsId { get; set; }
        [Required]
        [DisplayName("Event Title")]

        public string EventTitle { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime Date { get; set; }
        [Required]

        public string Location { get; set; }
        [Required]
        public string Type { get; set; }
        
        [DisplayName("Duration")]
        [Range(1,10)]
        public int DurationInHours { get; set; }
        
        [MaxLength(50)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        
        [MaxLength(500)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Other Details")]
        public string OtherDescription { get; set; }
        
        [DataType(DataType.MultilineText)]
        [Display(Name = "Invite By Emails")]
        public string InvitByEmail { get; set; }

        public int? UserId { get; set; }
    }
}