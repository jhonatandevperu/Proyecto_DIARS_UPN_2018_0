using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaAccesoDatos;

namespace CapaLogica
{
    public class logUsuario
    {
        #region singleton
        private static readonly logUsuario _instancia = new logUsuario();
        public static logUsuario Instancia
        {
            get { return logUsuario._instancia; }
        }
        #endregion

        #region Metodos
        public List<entUsuario> ListarUsuarios()
        {
            try
            {
                return datUsuario.Instancia.ListarUsuarios();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public entUsuario ObtenerUsuario(int UsuarioID)
        {
            try
            {
                return datUsuario.Instancia.ObtenerUsuario(UsuarioID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public entUsuario VerificarNombreusuarioContrasenausuario(string Nombreusuario, string Contrasenausuario)
        {
            try
            {
                return datUsuario.Instancia.VerificarNombreusuarioContrasenausuario(Nombreusuario, Contrasenausuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertarUsuario(entUsuario Usuario)
        {
            try
            {
                return datUsuario.Instancia.InsertarUsuario(Usuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EditarUsuario(entUsuario Usuario)
        {
            try
            {
                return datUsuario.Instancia.EditarUsuario(Usuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EliminarUsuario(int UsuarioID)
        {
            try
            {
                return datUsuario.Instancia.EliminarUsuario(UsuarioID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
