using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace EscalaConstructoresSAC.Controllers
{
    public class TareaController : Controller
    {
        [HttpGet]
        public ActionResult ListaTareas()
        {
            List<entTarea> lista = logTarea.Instancia.ListarTareas();
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult NuevaTarea()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevaTarea(entTarea Tarea)
        {
            try
            {
                Boolean inserta = logTarea.Instancia.InsertarTarea(Tarea);
                if (inserta)
                {
                    return RedirectToAction("ListaTareas");
                }
                else
                {
                    return View(Tarea);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaTareas", new { msjException = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult EditaTarea(int TareaID)
        {
            entTarea Tarea = logTarea.Instancia.ObtenerTarea(TareaID);
            if (Tarea == null)
            {
                return HttpNotFound();
            }
            return View(Tarea);
        }

        [HttpPost]
        public ActionResult EditaTarea(entTarea Tarea)
        {
            try
            {
                Boolean edita = logTarea.Instancia.EditarTarea(Tarea);

                if (edita)
                {
                    return RedirectToAction("ListaTareas");
                }
                else
                {
                    return View(Tarea);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaTareas", new { msjException = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult EliminaTarea(int TareaID)
        {
            try
            {
                Boolean edita = logTarea.Instancia.EliminarTarea(TareaID);
                return RedirectToAction("ListaTareas");
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaTareas", new { msjException = ex.Message });
            }
        }
    }
}
