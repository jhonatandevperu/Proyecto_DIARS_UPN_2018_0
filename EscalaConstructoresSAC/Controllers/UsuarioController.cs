using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace EscalaConstructoresSAC.Controllers
{
    public class UsuarioController : Controller
    {
        public static int ResidenteID { get; set; }

        [HttpGet]
        public ActionResult ListaUsuarios()
        {
            List<entUsuario> lista = logUsuario.Instancia.ListarUsuarios();
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult NuevoUsuario(int ResidenteID)
        {
            UsuarioController.ResidenteID = ResidenteID;
            return View(new entUsuario { Residente = logResidente.Instancia.ObtenerResidente(ResidenteID) });
        }

        [HttpPost]
        public ActionResult NuevoUsuario(entUsuario Usuario)
        {
            try
            {
                Usuario.Residente = logResidente.Instancia.ObtenerResidente(UsuarioController.ResidenteID);
                Boolean inserta = logUsuario.Instancia.InsertarUsuario(Usuario);
                if (inserta)
                {
                    return RedirectToAction("ListaUsuarios");
                }
                else
                {
                    return View(Usuario);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaUsuarios", new { msjException = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult EditaUsuario(int UsuarioID)
        {
            entUsuario Usuario = logUsuario.Instancia.ObtenerUsuario(UsuarioID);
            if (Usuario == null)
            {
                return HttpNotFound();
            }
            return View(Usuario);
        }

        [HttpPost]
        public ActionResult EditaUsuario(entUsuario Usuario)
        {
            try
            {
                Usuario.Residente = logResidente.Instancia.ObtenerResidente(UsuarioController.ResidenteID);
                Boolean edita = logUsuario.Instancia.EditarUsuario(Usuario);

                if (edita)
                {
                    return RedirectToAction("ListaUsuarios");
                }
                else
                {
                    return View(Usuario);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaUsuarios", new { msjException = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult EliminaUsuario(int UsuarioID)
        {
            try
            {
                Boolean edita = logUsuario.Instancia.EliminarUsuario(UsuarioID);
                return RedirectToAction("ListaUsuarios");
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("ListaUsuarios", new { msjException = ex.Message });
            }
        }
    }
}