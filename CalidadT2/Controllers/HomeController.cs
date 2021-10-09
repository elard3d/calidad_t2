using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using CalidadT2.Respositories;

namespace CalidadT2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeRepository repositoryH;
        public HomeController(IHomeRepository repositoryH)
        {
            this.repositoryH = repositoryH;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = repositoryH.ListaLibros();
            return View(model);
        }
    }
}
