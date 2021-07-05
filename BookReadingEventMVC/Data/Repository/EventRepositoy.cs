using AutoMapper;
using BookReadingEventMVC.Data.Entities;
using BookReadingEventMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingEventMVC.Data.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly EventsContext _context = null;
        public EventRepository(EventsContext context)
        {
            _context = context;
        }
        public List<EventViewModel> GetEvent()
        {
            
            var events = _context.Events.ToList();
            List<EventViewModel> eventDTOList = new List<EventViewModel>();
            foreach (var item in events)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Event, EventViewModel>());
                var mapper = config.CreateMapper();
                EventViewModel eventsDTO = mapper.Map<Event, EventViewModel>(item);

                eventDTOList.Add(eventsDTO);
            }

            return eventDTOList;
        }
        private static List<Event> NewMethod(EventsContext context)
        {
            return context.Events.ToList();
        }
        public void CreateEvent(EventViewModel eventDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EventViewModel, Event>());
            var mapper = config.CreateMapper();
            Event events = mapper.Map<EventViewModel, Event>(eventDTO);

            _context.Events.Add(events);
            _context.SaveChanges();
            string str = eventDTO.InvitByEmail;
            if (str != null)
            {
                string[] invitelist = str.Split(',');
                foreach (string eventInvitedto in invitelist)
                {
                    EventInvited eventInvitedTo = new EventInvited();
                    var userdetails = _context.Userss.Where(x => x.Email == eventInvitedto).FirstOrDefault();
                    if (userdetails != null)
                    {

                        eventInvitedTo.UserId = userdetails.User_Id;
                        eventInvitedTo.EventsId = events.EventsId;
                        _context.EventInviteds.Add(eventInvitedTo);
                        _context.SaveChanges();
                        
                    }

                }
            }
        }
        public void DeleteEvent(int id)
        {
            

            var events = _context.Events.Where(x => x.EventsId == id).FirstOrDefault();
            _context.Events.Remove(events);
            _context.SaveChanges();
        }
        public EventViewModel EditEvent(int? id)
        {
            
            var events = _context.Events.Where(x => x.EventsId == id).FirstOrDefault();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Event, EventViewModel>());
            var mapper = config.CreateMapper();
            EventViewModel eventsDTO = mapper.Map<Event, EventViewModel>(events);

            return eventsDTO;
        }
        public void SaveEvent(EventViewModel eventDTO)
        {
            



            Event events = _context.Events.Where(x => x.EventsId == eventDTO.EventsId).FirstOrDefault();



            events.Description = eventDTO.Description;
            events.Date = eventDTO.Date;
            events.DurationInHours = eventDTO.DurationInHours;
            events.EventTitle = eventDTO.EventTitle;
            events.Location = eventDTO.Location;
            events.OtherDescription = eventDTO.OtherDescription;
            events.Type = eventDTO.Type;
            events.InvitByEmail = eventDTO.InvitByEmail;



            _context.SaveChanges();
        }




        public EventViewModel GetDetails(int id)
        {
           
            Event events = _context.Events.Where(x => x.EventsId == id).FirstOrDefault();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Event, EventViewModel>());
            var mapper = config.CreateMapper();
            EventViewModel eventsDTO = mapper.Map<Event, EventViewModel>(events);
            return eventsDTO;

        }
        public List<EventViewModel> MyEvents(int? id)
        {

            
            var myEventlist = _context.Events.Where(x => x.UserId == id).ToList();
            List<EventViewModel> eventsDTOlist = new List<EventViewModel>();
            foreach (var item in myEventlist)
            {

                var config = new MapperConfiguration(cfg => cfg.CreateMap<Event, EventViewModel>());
                var mapper = config.CreateMapper();
                EventViewModel eventsDTO = mapper.Map<Event, EventViewModel>(item);
                eventsDTOlist.Add(eventsDTO);

            }
            return eventsDTOlist;
        }
        public void SaveComment(CommentViewModel commentDTO)
        {
           
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CommentViewModel, Comment>());
            var mapper = config.CreateMapper();
            Comment comment = mapper.Map<CommentViewModel, Comment>(commentDTO);

            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public List<CommentViewModel> GetAllComments()
        {
           

            List<Comment> comment = _context.Comments.ToList();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentViewModel>());
            var mapper = config.CreateMapper();
            List<CommentViewModel> commentsDTOList = mapper.Map<List<Comment>, List<CommentViewModel>>(comment);

            return commentsDTOList;
        }
        public List<EventViewModel> EventsInvited(int id)
        {
           
            List<EventViewModel> eventDTOlist = new List<EventViewModel>();
            List<EventInvited> eventInvited = _context.EventInviteds.ToList();
            foreach (var item in eventInvited)
            {

                if (id == item.UserId)
                {
                    Event eventsentity = _context.Events.Where(x => x.EventsId == item.EventsId).FirstOrDefault();
                    if (eventsentity != null)
                    {
                        EventViewModel eventDTO = new EventViewModel();
                        eventDTO.EventTitle = eventsentity.EventTitle;
                        eventDTO.Location = eventsentity.Location;
                        eventDTO.Date = eventsentity.Date;
                        eventDTO.Description = eventsentity.Description;
                        eventDTO.DurationInHours = eventsentity.DurationInHours;
                        eventDTO.InvitByEmail = eventsentity.InvitByEmail;
                        eventDTO.DurationInHours = eventsentity.DurationInHours;
                        eventDTO.OtherDescription = eventsentity.OtherDescription;
                        eventDTO.Type = eventsentity.Type;
                        eventDTO.EventsId = eventsentity.EventsId;
                        eventDTOlist.Add(eventDTO);
                    }
                }

            }
            return eventDTOlist;
        }
    }
}
