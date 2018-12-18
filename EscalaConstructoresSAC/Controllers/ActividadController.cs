using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace EscalaConstructoresSAC.Controllers
{
    public class ActividadController : Controller
    {
        [HttpGet]
        public ActionResult ListaActividades()
        {
            List<entActividad> lista = logActividad.Instancia.ListarActividades();
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult NuevaActividad()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevaActividad(entActividad Actividad)
        {
            try
            {
                Boolean inserta = logActividad.Instancia.InsertarActividad(Actividad);
                if (inserta)
                {
                    return RedirectToAction("ListaActividades");
                }
                else
                {
                    return View(Actividad);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaActividades", new { msjException = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult EditaActividad(int ActividadID)
        {
            entActividad actividad = logActividad.Instancia.ObtenerActividad(ActividadID);
            if (actividad == null)
            {
                return HttpNotFound();
            }
            return View(actividad);
        }

        [HttpPost]
        public ActionResult EditaActividad(entActividad Actividad)
        {
            try
            {
                Boolean edita = logActividad.Instancia.EditarActividad(Actividad);

                if (edita)
                {
                    return RedirectToAction("ListaActividades");
                }
                else
                {
                    return View(Actividad);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaActividades", new { msjException = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult EliminaActividad(int ActividadID)
        {
            try
            {
                Boolean elimina = logActividad.Instancia.EliminarActividad(ActividadID);
                return RedirectToAction("ListaActividades");
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaActividades", new { msjException = ex.Message });
            }
        }
    }
}
