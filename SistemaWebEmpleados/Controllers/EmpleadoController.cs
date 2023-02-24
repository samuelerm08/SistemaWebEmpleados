using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using SistemaWebEmpleados.Data;
using SistemaWebEmpleados.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SistemaWebEmpleados.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly DBEmpleadosContext context;

        public EmpleadoController(DBEmpleadosContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var empleados = context.Empleados.ToList();
            return View(empleados);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var empleado = new Empleado();
            return View("Create", empleado);
        }

        [HttpPost]
        public ActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                var legajoExists = context.Empleados.Any(i => i.Legajo == empleado.Legajo);
                var dniExists = context.Empleados.Any(i => i.DNI == empleado.DNI);

                if (legajoExists)
                {
                    ModelState.AddModelError("Legajo", "El legajo ingresado existe. Por favor, ingresar nuevamente");
                    return View(empleado);
                }

                if (dniExists)
                {
                    ModelState.AddModelError("DNI", "El DNI ingresado existe. Por favor, ingresar nuevamente");
                    return View(empleado);
                }

                context.Empleados.Add(empleado);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleado);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var empleado = ObtenerUno(id);
            if (empleado == null)
                return NotFound();
            else
                return View("Details", empleado);
        }

        [HttpGet]
        public IActionResult Filter(string text)
        {
            var empleados = (from e in context.Empleados
                             where e.Nombre == text || e.Apellido == text
                             select e).ToList();

            if (empleados == null)
                return NotFound();

            return View(nameof(Index), empleados);
        }

        [HttpGet]
        public IActionResult DetailsByTitle(string title)
        {
            var empleados = context.Empleados.Where(i => i.Titulo == title).ToList();

            if (empleados == null)
                return NotFound();

            return View("DetailsByTitle", empleados);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var empleado = ObtenerUno(id);

            if (empleado == null)
                return NotFound();

            return View("Delete", empleado);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var empleado = ObtenerUno(id);
            if (empleado == null)
                return NotFound();
            else
            {
                context.Empleados.Remove(empleado);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var empleado = ObtenerUno(id);
            return View("Edit", empleado);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(Empleado empleado)
        {
            if (!ModelState.IsValid) return BadRequest();

            context.Entry(empleado).State = EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        private Empleado ObtenerUno(int id)
        {
            return context.Empleados.Find(id);
        }
    }
}

