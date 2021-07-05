﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingEventMVC.Models.ViewModels
{
    public class EventViewModel
    {
        public int EventsId { get; set; }

        public string EventTitle { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public string Type { get; set; }

        public int DurationInHours { get; set; }

        public string Description { get; set; }
        public string OtherDescription { get; set; }
        public string InvitByEmail { get; set; }

        public int? UserId { get; set; }
    }
}
