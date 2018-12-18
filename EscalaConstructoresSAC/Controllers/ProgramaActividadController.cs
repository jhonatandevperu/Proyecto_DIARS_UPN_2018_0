using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace EscalaConstructoresSAC.Controllers
{
    public class ProgramaActividadController : Controller
    {
        public static int ProgramaID { get; set; }

        [HttpGet]
        public ActionResult ListaActividadesDePrograma(int ProgramaID)
        {
            ProgramaActividadController.ProgramaID = ProgramaID;
            List<entProgramaActividad> lista = logProgramaActividad.Instancia.ListarActividadesDePrograma(ProgramaID);
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult QuitaActividadDePrograma(int ActividadID)
        {
            try
            {
                Boolean quita = logProgramaActividad.Instancia.EliminarActividadDePrograma(ProgramaActividadController.ProgramaID, ActividadID);
                return RedirectToAction("ListaActividadesDePrograma", new { Programa = ProgramaActividadController.ProgramaID });
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaActividadesDePrograma", new { msjException = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult ListaActividadesDisponibles()
        {
            List<entProgramaActividad> lista = logProgramaActividad.Instancia.ListarActividadesNoDentroDePrograma(ProgramaActividadController.ProgramaID);
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult AgregaNuevaActividad(int ActividadID)
        {
            try
            {
                Boolean agrega = logProgramaActividad.Instancia.InsertarActividadAPrograma(new entProgramaActividad { Programa = logPrograma.Instancia.ObtenerPrograma(ProgramaActividadController.ProgramaID), Actividad = logActividad.Instancia.ObtenerActividad(ActividadID) });
                return RedirectToAction("ListaActividadesDePrograma", new { ProgramaID = ProgramaActividadController.ProgramaID });
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaProgramas", "Programa", new { msjException = ex.Message });
            }
        }
    }
}
