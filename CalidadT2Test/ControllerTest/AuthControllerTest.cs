using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Respositories;
using CalidadT2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalidadT2Test.ControllerTest
{
    class AuthControllerTest
    {
        [Test]
        public void Login_Correcto()
        {
            var mockRepository = new Mock<IAuthRepository>();
            var cookie = new Mock<ICookieAuthService>();
            mockRepository.Setup(o => o.FindUser("admin", It.IsAny<String>()))
                .Returns(new Usuario { Username = "admin", Password = "admin" });


            var controller = new AuthController(mockRepository.Object, cookie.Object);

            var view = controller.Login("admin", "admin");

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }

        [Test]
        public void Login_Erroneo()
        {
            var mockRepository = new Mock<IAuthRepository>();
            var cookie = new Mock<ICookieAuthService>();
            mockRepository.Setup(o => o.FindUser("admin", It.IsAny<String>()));


            var controller = new AuthController(mockRepository.Object, cookie.Object);

            var view = controller.Login("admin", "123");

            Assert.IsInstanceOf<ViewResult>(view);
        }
    }
}
