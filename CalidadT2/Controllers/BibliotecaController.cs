using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CalidadT2.Constantes;
using CalidadT2.Models;
using CalidadT2.Respositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    [Authorize]
    public class BibliotecaController : Controller
    {
        private readonly IAuthRepository repository;
        private readonly IBibliotecaRepository repositoryB;

        public BibliotecaController(IAuthRepository repository, IBibliotecaRepository repositoryB)
        {
            this.repositoryB = repositoryB;
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Usuario user = LoggedUser();

            var model = repositoryB.ListaLibrosBiblioteca(user);

            return View(model);
        }

        [HttpGet]
        public ActionResult Add(int libro)
        {
            Usuario user = LoggedUser();

            repositoryB.AgregarABiblioteca(libro, user);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult MarcarComoLeyendo(int libroId)
        {
            Usuario user = LoggedUser();

            repositoryB.MarcadoLeyendo(libroId, user);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MarcarComoTerminado(int libroId)
        {
            Usuario user = LoggedUser();

            repositoryB.MarcadoTerminado(libroId, user);

            return RedirectToAction("Index");
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
