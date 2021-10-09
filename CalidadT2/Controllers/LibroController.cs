using System;
using System.Linq;
using CalidadT2.Models;
using CalidadT2.Respositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    public class LibroController : Controller
    {
        private readonly IAuthRepository repository;
        private readonly ILibroRepository repositoryL;

        public LibroController(IAuthRepository repository, ILibroRepository repositoryL)
        {
            this.repository = repository;
            this.repositoryL = repositoryL;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = repositoryL.GetDetail(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddComentario(Comentario comentario)
        {
            Usuario user = LoggedUser();

            repositoryL.AddComentario(user, comentario);

            return RedirectToAction("Details", new { id = comentario.LibroId });
        }

        private Usuario LoggedUser()
        {
            //var claim = HttpContext.User.Claims.FirstOrDefault();
            //var user = repository.GetUserLogin(claim);
            var user = new Usuario { Id = 1, Nombres = "Luigui Mendoza", Username = "admin", Password = "admin" };
            return user;
        }
    }
}
