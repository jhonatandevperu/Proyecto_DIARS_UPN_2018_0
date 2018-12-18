using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace EscalaConstructoresSAC.Controllers
{
    public class ActividadTareaController : Controller
    {
        public static int ActividadID;

        [HttpGet]
        public ActionResult ListaTareasDeActividad(int ActividadID)
        {
            ActividadTareaController.ActividadID = ActividadID;
            List<entActividadTarea> lista = logActividadTarea.Instancia.ListarTareasDeActividad(ActividadID);
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult QuitaTareaDeActividad(int TareaID)
        {
            try
            {
                Boolean quita = logActividadTarea.Instancia.EliminarTareaDeActividad(ActividadTareaController.ActividadID, TareaID);
                return RedirectToAction("ListaTareasDeActividad", new { ActividadID = ActividadTareaController.ActividadID });
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaTareasDeActividad", new { msjException = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult ListaTareasDisponibles()
        {
            List<entActividadTarea> lista = logActividadTarea.Instancia.ListarTareasNoDentroDeActividad(ActividadTareaController.ActividadID);
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult AgregaNuevaTarea(int TareaID)
        {
            try
            {
                Boolean agrega = logActividadTarea.Instancia.InsertarTareaAActividad(new entActividadTarea { Actividad = logActividad.Instancia.ObtenerActividad(ActividadTareaController.ActividadID), Tarea = logTarea.Instancia.ObtenerTarea(TareaID) });
                return RedirectToAction("ListaTareasDeActividad", new { ActividadID = ActividadTareaController.ActividadID });
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaActividades", "Actividad", new { msjException = ex.Message });
            }
        }
    }
}
