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
    class BibliotecaControllerTest
    {
        [Test]
        public void ObtenerListaLibros_Correctamente()
        {
            var repositoryB = new Mock<IBibliotecaRepository>();
            var mockRepository = new Mock<IAuthRepository>();
            var controller = new BibliotecaController(mockRepository.Object,repositoryB.Object);
            var view = controller.Index();
            Assert.IsInstanceOf<ViewResult>(view);
        }

        [Test]
        public void AgregarBiblioteca()
        {
            var repositoryB = new Mock<IBibliotecaRepository>();
            var mockRepository = new Mock<IAuthRepository>();
            var controller = new BibliotecaController(mockRepository.Object, repositoryB.Object);

            var view = controller.Add(1);

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }

        [Test]
        public void MarcarLeyendo()
        {
            var repositoryB = new Mock<IBibliotecaRepository>();
            var mockRepository = new Mock<IAuthRepository>();
            var controller = new BibliotecaController(mockRepository.Object, repositoryB.Object);

            var view = controller.MarcarComoLeyendo(4);

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }

        [Test]
        public void MarcarTerminado()
        {
            var repositoryB = new Mock<IBibliotecaRepository>();
            var mockRepository = new Mock<IAuthRepository>();
            var controller = new BibliotecaController(mockRepository.Object, repositoryB.Object);

            var view = controller.MarcarComoTerminado(4);

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
    }
}
