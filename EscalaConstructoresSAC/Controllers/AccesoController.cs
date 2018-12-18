using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;
using System.Web.UI;

namespace EscalaConstructoresSAC.Controllers
{
    public class AccesoController : Controller
    {
        public static int ResidenteID { get; set; }
        public static string Nombreusuario { get; set; }

        [HttpGet]
        public ActionResult IniciarSesion()
        {
            return View();
        }
        [HttpPost]
        public ActionResult VerificarAcceso(FormCollection frm)
        {
            try
            {
                String Usuario = frm["txtUsuario"].ToString();
                String Password = frm["txtPassword"].ToString();
                entUsuario u = logUsuario.Instancia.VerificarNombreusuarioContrasenausuario(Usuario, Password);

                if (u.Residente != null)
                {
                    if (!u.Estadousuario)
                    {

                        return RedirectToAction("IniciarSesion",
                            new { msg = "Su usuario ha sido dado de baja" });
                    }
                    AccesoController.ResidenteID = u.Residente.ResidenteID;
                    AccesoController.Nombreusuario = u.Nombreusuario;
                    return RedirectToAction("Index", "Home", new { });
                }
                return RedirectToAction("IniciarSesion", "Acceso");
            }
            catch (Exception e)
            {
                return RedirectToAction("IniciarSesion", "Acceso", new { msgError = e.Message });
            }
        }

        public ActionResult MensajeError()
        {
            Response.Write(" <script>alert('Error de Acceso'); </script>");
            return RedirectToAction("IniciarSesion", "Acceso");
        }
    }
}