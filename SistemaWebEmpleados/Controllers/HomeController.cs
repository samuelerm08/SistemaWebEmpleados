using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SistemaWebEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebEmpleados.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Bienvenida = "Bienvenido al Sistema de Empleados";
            ViewBag.Fecha = DateTime.Now;
            return View();
        }           
    }
}
