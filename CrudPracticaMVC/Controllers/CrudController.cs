using CrudPracticaMVC.Datos;
using CrudPracticaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CrudPracticaMVC.Controllers
{
    public class CrudController : Controller
    {
        
        public IActionResult Index()
        {
            CrudCoches crudCoches = new CrudCoches();
            var lista = crudCoches.getcoches();
            return View(lista);
        }
        
        public IActionResult Guardar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            return View();
        }
        public IActionResult Eliminar(int id)
        {
            CrudCoches crudCoches = new CrudCoches();
            crudCoches.Delete(id);
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Guardar(CochesModel coches)
        {
            CrudCoches crudCoches = new CrudCoches();
            crudCoches.Insert(coches);
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Editar(CochesModel coches)
        {
            CrudCoches crudCoches = new CrudCoches();
            crudCoches.Edit(coches);
			return RedirectToAction("index");
		}

    }
}
