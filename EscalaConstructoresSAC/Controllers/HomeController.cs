using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace EscalaConstructoresSAC.Controllers
{
    public class HomeController : Controller
    {
        public static int TotalNroObras { get; set; }
        public static int TotalNroProgramas { get; set; }
        public static int TotalNroActividades { get; set; }
        public static int TotalNroTareas { get; set; }

        private static void CargarTotales()
        {
            List<entObra> obras = logObra.Instancia.ListarObras();
            List<entPrograma> programas = logPrograma.Instancia.ListarProgramas();
            List<entActividad> actividades = logActividad.Instancia.ListarActividades();
            List<entTarea> tareas = logTarea.Instancia.ListarTareas();
            foreach (entObra obra in obras){TotalNroObras++;}
            foreach (entPrograma programa in programas) { TotalNroProgramas++; }
            foreach (entActividad actividad in actividades) { TotalNroActividades++; }
            foreach (entTarea tarea in tareas) { TotalNroTareas++; }
        }

        public ActionResult Index()
        {
            TotalNroObras = TotalNroProgramas = TotalNroActividades = TotalNroTareas = 0;
            CargarTotales();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}