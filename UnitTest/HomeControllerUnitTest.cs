using BookReadingEventMVC.Controllers;
using BookReadingEventMVC.Data.Repository;
using BookReadingEventMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTest
{
    public class HomeControllerUnitTests
    {
        private readonly EventController _sut;
        private readonly UserController _sut1;
        private readonly HomeController _sut2;
        private readonly Mock<IEventRepository> _EventRepoMock = new Mock<IEventRepository>();
        private readonly Mock<IUserRepository> _UserRepoMock = new Mock<IUserRepository>();
        private readonly Mock<IMapperHelper> _MapperRepoMock = new Mock<IMapperHelper>();
        public HomeControllerUnitTests()
        {
            _sut = new EventController(_EventRepoMock.Object,_MapperRepoMock.Object);
            _sut1 = new UserController(_UserRepoMock.Object, _EventRepoMock.Object);
            _sut2 = new HomeController(Mock.Of<ILogger<HomeController>>(), _EventRepoMock.Object,_MapperRepoMock.Object);
        }
        


        [Fact]
        public void Test_Index_ViewResult()
        {
            // Arrnge
            List<EventViewModel> list = new List<EventViewModel>();
            list.Add(new EventViewModel
            {
                Description = "Description of Event"
            });
            _EventRepoMock.Setup(m => m.GetEvent()).Returns(list);

            // Act
            var result = _sut2.Index();
            // Assert
            Assert.IsAssignableFrom<ViewResult>(result);
        }
      
       
        [Fact]
        public void Test_SignUp()
        {
            // Act
            ViewResult result = _sut1.SignUp() as ViewResult;

            // Assert
            Assert.True("SignUp".Equals(result.ViewName));
        }

    }
}
