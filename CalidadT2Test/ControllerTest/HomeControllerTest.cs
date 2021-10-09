using CalidadT2.Controllers;
using CalidadT2.Respositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalidadT2Test.ControllerTest
{
    class HomeControllerTest
    {
        [Test]
        public void ObtenerListaLibros_Correctamente()
        {
            var repositoryH = new Mock<IHomeRepository>();
            var controller = new HomeController(repositoryH.Object);
            var view = controller.Index();
            Assert.IsInstanceOf<ViewResult>(view);
        }
    }
}