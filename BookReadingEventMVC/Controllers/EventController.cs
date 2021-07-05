using AutoMapper;
using BookReadingEventMVC.Data.Repository;
using BookReadingEventMVC.Models;
using BookReadingEventMVC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace BookReadingEventMVC.Controllers
{
   
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository = null;
        private readonly IMapperHelper _mapper;
        public static int id;
        public EventController(IEventRepository eventRepository, IMapperHelper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
        // GET: Event

        public  ActionResult CreateEvent()
        {
            ViewBag.Id = id;
            Console.WriteLine(ViewBag.Id);
            if (ViewBag.Id==0)
            {
                return RedirectToAction("Login", "User");
            }

            return  View();
        }

        [HttpPost]
        public ActionResult CreateEvent(Event events)
        {
           
            ViewBag.Id = id;
            EventViewModel eventsDTO = new EventViewModel();
            eventsDTO.EventTitle = events.EventTitle;
            eventsDTO.Location = events.Location;
            eventsDTO.Date = events.Date;
            eventsDTO.Type = events.Type;
            eventsDTO.Description = events.Description;
            eventsDTO.DurationInHours = events.DurationInHours;
            eventsDTO.InvitByEmail = events.InvitByEmail;
            eventsDTO.OtherDescription = events.OtherDescription;
            eventsDTO.UserId = id;
            
            _eventRepository.CreateEvent(eventsDTO);
            if (eventsDTO.UserId==1)
            {
                return RedirectToAction("LoggedIn","User");
            }
            return  RedirectToAction("LoginUser", "Home");
        }
        [HttpGet]
        public ActionResult MyEvents(int? id)
        {
            id = EventController.id;
            ViewBag.Id = id;
            if (ViewBag.Id == 0)
            {
                return RedirectToAction("Login", "User");
            }

            List<Event> eventslist = new List<Event>();
            var myeventsDTOlist = _eventRepository.MyEvents(id);

            foreach (var item in myeventsDTOlist)
            {
                Event events = new Event();
                events.EventTitle = item.EventTitle;
                events.Location = item.Location;
                events.Date = item.Date;
                events.DurationInHours = item.DurationInHours;
                events.Description = item.Description;
                events.OtherDescription = item.OtherDescription;
                events.InvitByEmail = item.InvitByEmail;
                events.Type = item.Type;
                events.EventsId = item.EventsId;
                eventslist.Add(events);
            }
            return View(eventslist);
        }
        [HttpGet]
        public ActionResult EditEvent(int? id)
        {
            ViewBag.Id = EventController.id;
            if (ViewBag.Id == null)
            {
                return RedirectToAction("Login", "User");
            }
          
            EventViewModel eventsDTO = new EventViewModel();


            eventsDTO = _eventRepository.EditEvent(id);
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<EventViewModel, Event>());
            //var mapper = config.CreateMapper();
            Event events = _mapper.getMapperEvent().Map<EventViewModel, Event>(eventsDTO);

            return View(events);
        }


        [HttpPost, ActionName("EditEvent")]
        public ActionResult SaveEvent(Event events)
        {
           
            EventViewModel eventsDTO = new EventViewModel();


            ViewBag.Id = id;
            eventsDTO = _mapper.getMapperEventView().Map<Event, EventViewModel>(events);

            _eventRepository.SaveEvent(eventsDTO);
            if (ViewBag.Id==1)
            {
                return RedirectToAction("LoggedIn", "User");
            }
            return RedirectToAction("LoginUser", "Home");
        }
    
        public ActionResult GetDetails(int Id)
        {
            ViewBag.Id = HomeController.id;
            if (Id == 0 )
            {
                return RedirectToAction("Login", "User");
            }
            var eventdetails = _eventRepository.GetDetails(Id);  
            Event events = _mapper.getMapperEvent().Map<EventViewModel, Event>(eventdetails);
            return View(events);
        }
        public ActionResult DeleteEvent(int id)
        {
            
            if (id == 0)
            {
                return RedirectToAction("Login", "User");
            }
            ViewBag.Id = HomeController.id;

            _eventRepository.DeleteEvent(id);

            if (ViewBag.Id==1)
            {
                return RedirectToAction("LoggedIn", "User");
            }
            return RedirectToAction("LoginUser", "Home");
        }
        public ActionResult AddComment(int id)
        {
            ViewBag.Id = HomeController.id;
            if (ViewBag.Id == 0)
            {
                return RedirectToAction("Login", "User");
            }
            Comment comment = new Comment();
            comment.EventsId = id;
            return View(comment);
        }
        public ActionResult SaveComment(Comment comment, int eventId)
        {
            ViewBag.Id = id;
            if (ViewBag.Id == 0)
            {
                return RedirectToAction("Login", "User");
            }
           
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentViewModel>());
            //var mapper = config.CreateMapper();
            CommentViewModel commentDTO = _mapper.getMapperComment().Map<Comment, CommentViewModel>(comment);

           

            commentDTO.UserId = id;

            commentDTO.EventsId = eventId;
            _eventRepository.SaveComment(commentDTO);
            return RedirectToAction("ShowComments");
        }
        public void setId(int Id)
        {
            id = Id;
        }


    }
}
