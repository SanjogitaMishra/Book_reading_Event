using AutoMapper;
using BookReadingEventMVC.Data.Repository;
using BookReadingEventMVC.Models;
using BookReadingEventMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace BookReadingEventMVC.Controllers
{    
    
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository = null;
        private readonly IEventRepository _eventRepository = null;
        private static int userId;

        public UserController(IUserRepository userRepository,IEventRepository eventRepository)
        {
            _userRepository = userRepository;
            _eventRepository = eventRepository;
        }
        // GET: User
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
           
            UserViewModel userDTO = new UserViewModel();
            userDTO.Email = user.Email;
            userDTO.Password = user.Password;
            int result = _userRepository.Login(userDTO);
            Console.WriteLine(result);
            if (result == -1)
            {
                return Content("invalid Credentials");
            }
            else
            {
                userId = result;
                HomeController.id = result;
                EventController.id = result;
                if (userDTO.Email.Equals("myadmin@bookevents.com"))
                {

                    return RedirectToAction("LoggedIn", "User");
                }
                else
                {
                    Console.WriteLine(result);
                    return RedirectToAction("LoginUser", "Home");
                }

            }

        }
        public ActionResult LoggedIn()
        {
            ViewBag.Id = userId;
            if (ViewBag.Id==0)
            {
                return RedirectToAction("Login", "User");
            }
            List<EventViewModel> eventsDTOList = new List<EventViewModel>();
            eventsDTOList = _eventRepository.GetEvent();
            List<Event> eventList = new List<Event>();

            foreach (var item in eventsDTOList)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<EventViewModel, Event>());
                var mapper = config.CreateMapper();
                Event events = mapper.Map<EventViewModel, Event>(item);

                eventList.Add(events);
            }

                return View(eventList);
           // return RedirectToAction("MyEvents", "Event");

        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View("SignUp");
        }


        [HttpPost]
        public ActionResult SignUp(User userModel)
        {
           
            UserViewModel userDTO = new UserViewModel();
            userDTO.First_Name = userModel.First_Name;
            userDTO.Last_Name = userModel.Last_Name;
            userDTO.Email = userModel.Email;
            userDTO.Password = userModel.Password;

            int result = _userRepository.SignUp(userDTO);
            return RedirectToAction("Login", "User");
        }
        public ActionResult Logout()
        {
           
            HomeController.id = 0;
            EventController.id = 0;
            ViewBag.data = 0;
           
            return RedirectToAction("Index", "Home");
        }

    }
}
