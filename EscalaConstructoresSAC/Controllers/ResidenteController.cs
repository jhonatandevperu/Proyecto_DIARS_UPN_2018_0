using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace EscalaConstructoresSAC.Controllers
{
    public class ResidenteController : Controller
    {
        [HttpGet]
        public ActionResult ListaResidentes()
        {
            List<entResidente> lista = logResidente.Instancia.ListarResidentes();
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult ListaResidentesSinUsuario()
        {
            List<entResidente> lista = logResidente.Instancia.ListarResidentesSinUsuarios();
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult NuevoResidente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoResidente(entResidente Residente)
        {
            try
            {
                Boolean inserta = logResidente.Instancia.InsertarResidente(Residente);
                if (inserta)
                {
                    return RedirectToAction("ListaResidentes");
                }
                else
                {
                    return View(Residente);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaResidentes", new { msjException = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult EditaResidente(int ResidenteID)
        {
            entResidente Residente = logResidente.Instancia.ObtenerResidente(ResidenteID);
            if (Residente == null)
            {
                return HttpNotFound();
            }
            return View(Residente);
        }

        [HttpPost]
        public ActionResult EditaResidente(entResidente Residente)
        {
            try
            {
                Boolean edita = logResidente.Instancia.EditarResidente(Residente);

                if (edita)
                {
                    return RedirectToAction("ListaResidentes");
                }
                else
                {
                    return View(Residente);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaResidentes", new { msjException = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult EliminaResidente(int ResidenteID)
        {
            try
            {
                Boolean edita = logResidente.Instancia.EliminarResidente(ResidenteID);
                return RedirectToAction("ListaResidentes");
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaResidentes", new { msjException = ex.Message });
            }
        }
    }
}