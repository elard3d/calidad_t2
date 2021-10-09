using CalidadT2.Controllers;
using CalidadT2.Models;
using CalidadT2.Respositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalidadT2Test.ControllerTest
{
    class LibroControllerTest
    {
        [Test]
        public void ObtenerDetalle()
        {
            var repositoryB = new Mock<ILibroRepository>();
            var mockRepository = new Mock<IAuthRepository>();
            var controller = new LibroController(mockRepository.Object, repositoryB.Object);
            var view = controller.Details(4);
            Assert.IsInstanceOf<ViewResult>(view);
        }

        [Test]
        public void AgregarComentario()
        {
            var repositoryB = new Mock<ILibroRepository>();
            var mockRepository = new Mock<IAuthRepository>();
            var controller = new LibroController(mockRepository.Object, repositoryB.Object);

            var view = controller.AddComentario(new Comentario());

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
    }
}
