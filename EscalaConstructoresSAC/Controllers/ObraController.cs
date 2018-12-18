using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace EscalaConstructoresSAC.Controllers
{
    public class ObraController : Controller
    {
        [HttpGet]
        public ActionResult ListaObras()
        {
            List<entObra> lista = logObra.Instancia.ListarObras();
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult NuevaObra()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevaObra(entObra Obra)
        {
            try
            {
                Boolean inserta = logObra.Instancia.InsertarObra(Obra);
                if (inserta)
                {
                    return RedirectToAction("ListaObras");
                }
                else
                {
                    return View(Obra);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaObras", new { msjException = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult EditaObra(int ObraID)
        {
            entObra obra = logObra.Instancia.ObtenerObra(ObraID);
            if (obra == null)
            {
                return HttpNotFound();
            }
            return View(obra);
        }

        [HttpPost]
        public ActionResult EditaObra(entObra Obra)
        {
            try
            {
                Boolean edita = logObra.Instancia.EditarObra(Obra);

                if (edita)
                {
                    return RedirectToAction("ListaObras");
                }
                else
                {
                    return View(Obra);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaObras", new { msjException = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult EliminaObra(int ObraID)
        {
            try
            {
                Boolean edita = logObra.Instancia.EliminarObra(ObraID);
                return RedirectToAction("ListaObras");
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaObras", new { msjException = ex.Message });
            }
        }
    }
}
