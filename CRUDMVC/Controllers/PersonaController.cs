using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDMVC.Models;
    
namespace CRUDMVC.Controllers
{
    public class PersonaController : Controller
    {

        public ActionResult Index()
        {
            IEnumerable<Persona> retorno = new List<Persona>();
            using(pruebamvcContext context = new pruebamvcContext())
            {
                retorno = (from d in context.Personas
                          select d).ToList();
            }
            ViewBag.message = "";
            return View(retorno);
        }

        public ActionResult Nuevo()
        {
            ViewBag.message = "";
            return View();
        }

        public ActionResult Guardar(Persona modelo)
        {
            using(pruebamvcContext context = new pruebamvcContext())
            {
                context.Add(modelo);
                context.SaveChanges();
                ViewBag.message = "Registro guardado correctamente.";
            }
            return View("Nuevo", modelo);
        }

        public ActionResult Detalle(int id = 0)
        {
            var modelo = new Persona();
            using(pruebamvcContext context = new pruebamvcContext())
            {
                modelo = (from d in context.Personas
                          where d.Id == id
                          select d).FirstOrDefault();
            }
            return View(modelo);
        }

        public ActionResult Modificar(int id = 0)
        {
            var modelo = new Persona();
            using (pruebamvcContext context = new pruebamvcContext())
            {
                modelo = (from d in context.Personas
                          where d.Id == id
                          select d).FirstOrDefault();
            }
            return View(modelo);
        }

        public ActionResult Actualizar(Persona modelo)
        {
            using(pruebamvcContext context = new pruebamvcContext())
            {
                context.Entry(modelo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                ViewBag.message = "Registro modificado correctamente.";
            }
            return View("Modificar", modelo);
        }

        public ActionResult Eliminar(int id = 0)
        {
            IEnumerable<Persona> retorno = new List<Persona>();
            using (pruebamvcContext context = new pruebamvcContext())
            {
                context.Entry(new Persona() { Id = id }).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                context.SaveChanges();
                ViewBag.message = "Registro eliminado correctamente.";
                
                retorno = (from d in context.Personas
                           select d).ToList();
            }
            return View("Index", retorno);
        }
    }
}
