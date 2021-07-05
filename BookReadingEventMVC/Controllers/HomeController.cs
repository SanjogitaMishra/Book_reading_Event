using AutoMapper;
using BookReadingEventMVC.Data.Repository;
using BookReadingEventMVC.Models;
using BookReadingEventMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;


namespace BookReadingEventMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapperHelper _mapper;
        private readonly ILogger _logger;
        public static int id;
        public HomeController(ILogger<HomeController> logger, IEventRepository eventRepository, IMapperHelper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _eventRepository = eventRepository;

        }

        public ActionResult LoginUser()
        {
            
            List<EventViewModel> eventsDTOList = new List<EventViewModel>();
            eventsDTOList = _eventRepository.GetEvent();
            List<Event> eventList = new List<Event>();
            foreach (var item in eventsDTOList)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<EventViewModel, Event>());
                var mapper = config.CreateMapper();
                Event events = _mapper.getMapperEvent().Map<EventViewModel, Event>(item);
                eventList.Add(events);
            }
            ViewBag.Id = id;
            return View(eventList);
        }
        public ActionResult Index()
        {
            _logger.LogDebug("");
            List<EventViewModel> eventsDTOList = _eventRepository.GetEvent();
            _logger.LogDebug("");
            List<Event> eventList = new List<Event>();
            foreach (var item in eventsDTOList)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<EventViewModel, Event>());
                var map= config.CreateMapper();
                Event events = map.Map<EventViewModel, Event>(item);
                eventList.Add(events);
            }
            return View(eventList);
        }

      

    

       

        public void setId(int Id)
        {
            id = Id;
        }
    }
}
