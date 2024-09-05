using GestionVehiculo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

using static GestionVehiculo.Data.AplicationDbContext;

namespace GestionVehiculo.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiculoController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Vehiculo = _context.Vehiculo.ToList();
            ViewBag.Marca = _context.Marca.ToList();
            return View();

        }

        [HttpGet]
        public IActionResult GetVehiculo()
        {
            var vehiculo = _context.Vehiculo.ToList();
            if (vehiculo == null)
            {
                return NotFound();
            }
            return Json(vehiculo);
        }

        [HttpPost]
        public IActionResult GetVehiculobyId(int id)
        {
            var vehiculo = _context.Vehiculo.Where(x => x.Id == id).SingleOrDefault();
            if (vehiculo == null)
            {
                return NotFound();
            }
            return Json(vehiculo);
        }


        [HttpGet]
        public IActionResult GetMarca()
        {
            var vehiculo = _context.Marca.ToList();
            if (vehiculo == null)
            {
                return NotFound();
            }
            return Json(vehiculo);
        }

        [HttpPost]
        public IActionResult Create(Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Vehiculo.Add(vehiculo);
                _context.SaveChanges();
                return Ok(new { message = "vehiculo creado correctamente" });
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Edit(Vehiculo vehiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Vehiculo.Update(vehiculo);
                _context.SaveChanges();
                return Ok(new { message = "vehiculo actualizado correctamente" });
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var vehiculo = _context.Vehiculo.Find(id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            _context.Vehiculo.Remove(vehiculo);
            _context.SaveChanges();

            return Ok(new { message = "vehiculo eliminado correctamente" });
        }
    }
}
