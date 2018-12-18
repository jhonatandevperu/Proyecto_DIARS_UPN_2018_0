using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace EscalaConstructoresSAC.Controllers
{
    public class ReportarController : Controller
    {
        public static int ObraID { get; set; }
        public static int ActividadID { get; set; }

        [HttpGet]
        public ActionResult ListaTotalObras()
        {
            List<entObra> lista = logObra.Instancia.ListarObras();
            ViewBag.lista = lista;
            return View(lista);
        }

        public ActionResult ListaTotalActividades()
        {
            List<entActividad> lista = logActividad.Instancia.ListarActividades();
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult ListaTotalProgramasActividades(int ObraID)
        {
            List<entProgramaActividad> lista = logProgramaActividad.Instancia.ReportarTotalProgramasActividades(ObraID, Controllers.AccesoController.ResidenteID);
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult ListaTotalActividadesTareas(int ActividadID)
        {
            List<entActividadTarea> lista = logActividadTarea.Instancia.ListarTareasDeActividad(ActividadID);
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult SeleccionaObra(int ObraID)
        {
            try
            {
                ReportarController.ObraID = ObraID;
                return RedirectToAction("ListaTotalProgramasActividades", new { ObraID = ObraID });
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaTotalProgramasActividades", new { msjException = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult SeleccionaActividad(int ActividadID)
        {
            try
            {
                ReportarController.ActividadID = ActividadID;
                return RedirectToAction("ListaTotalActividadesTareas", new { ActividadID = ActividadID });
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaTotalActividadesTareas", new { msjException = ex.Message });
            }
        }
    }
}