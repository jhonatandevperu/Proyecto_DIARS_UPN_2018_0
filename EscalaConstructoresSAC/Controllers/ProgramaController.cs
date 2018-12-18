using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace EscalaConstructoresSAC.Controllers
{
    public class ProgramaController : Controller
    {
        public static int ObraID { get; set; }
        public static int ResidenteID { get; set; }

        [HttpGet]
        public ActionResult ListaSeleccionarObra()
        {
            List<entObra> lista = logObra.Instancia.ListarObras();
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult ListaProgramas(int ObraID)
        {
            ProgramaController.ObraID = ObraID;
            ProgramaController.ResidenteID = AccesoController.ResidenteID;
            List<entPrograma> lista = logPrograma.Instancia.ListarProgramasDeObrayDeResidente(ObraID, ProgramaController.ResidenteID);
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult NuevoPrograma()
        {
            return View(new entPrograma { Obra = logObra.Instancia.ObtenerObra(ProgramaController.ObraID), Residente = logResidente.Instancia.ObtenerResidente(ProgramaController.ResidenteID) , Fechainicioprograma = DateTime.Today, Fechafinprograma = DateTime.Today});
        }

        [HttpPost]
        public ActionResult NuevoPrograma(entPrograma Programa)
        {
            try
            {
                Programa.Obra = logObra.Instancia.ObtenerObra(ProgramaController.ObraID);
                Programa.Residente = logResidente.Instancia.ObtenerResidente(ProgramaController.ResidenteID);
                Boolean inserta = logPrograma.Instancia.InsertarPrograma(Programa);
                if (inserta)
                {
                    return RedirectToAction("ListaProgramas", new { ObraID = Programa.Obra.ObraID });
                }
                else
                {
                    return View(Programa);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaProgramas", new { msjException = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult EditaPrograma(int ProgramaID)
        {
            entPrograma Programa = logPrograma.Instancia.ObtenerPrograma(ProgramaID);
            if (Programa == null)
            {
                return HttpNotFound();
            }
            return View(Programa);
        }

        [HttpPost]
        public ActionResult EditaPrograma(entPrograma Programa)
        {
            try
            {
                Programa.Obra = logObra.Instancia.ObtenerObra(ProgramaController.ObraID);
                Programa.Residente = logResidente.Instancia.ObtenerResidente(ProgramaController.ResidenteID);
                Boolean edita = logPrograma.Instancia.EditarPrograma(Programa);

                if (edita)
                {
                    return RedirectToAction("ListaProgramas", new { ObraID = Programa.Obra.ObraID });
                }
                else
                {
                    return View(Programa);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaProgramas", new { msjException = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult EliminaPrograma(int ProgramaID)
        {
            try
            {
                Boolean edita = logPrograma.Instancia.EliminarPrograma(ProgramaID);
                return RedirectToAction("ListaProgramas", new { ObraID = ProgramaController.ObraID });
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaProgramas", new { msjException = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult SeleccionaObra(int ObraID)
        {
            try
            {
                return RedirectToAction("ListaProgramas", new { ObraID = ObraID });
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaProgramas", new { msjException = ex.Message });
            }
        }
    }
}
