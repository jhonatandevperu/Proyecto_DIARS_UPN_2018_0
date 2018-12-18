using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDatos
{
    public class datUsuario
    {
        #region singleton
        private static readonly datUsuario _instancia = new datUsuario();
        public static datUsuario Instancia
        {
            get { return datUsuario._instancia; }
        }
        #endregion

        #region Metodos
        public List<entUsuario> ListarUsuarios()
        {
            SqlCommand cmd = null;
            List<entUsuario> lista = new List<entUsuario>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_LISTARUSUARIOS", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entUsuario usuario = new entUsuario();
                    usuario.UsuarioID = Convert.ToInt16(dr["UsuarioID"]);
                    usuario.Nombreusuario = dr["Nombreusuario"].ToString();
                    usuario.Contrasenausuario = dr["Contrasenausuario"].ToString();
                    usuario.Estadousuario = Convert.ToBoolean(dr["Estadousuario"]);
                    usuario.Residente = datResidente.Instancia.ObtenerResidente(Convert.ToInt16(dr["ResidenteID"]));
                    lista.Add(usuario);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public Boolean InsertarUsuario(entUsuario usuario)
        {
            SqlCommand cmd = null;
            Boolean Inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_INSERTARUSUARIO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrContrasenausuario", usuario.Contrasenausuario);
                cmd.Parameters.AddWithValue("@prmblEstadousuario", usuario.Estadousuario);
                cmd.Parameters.AddWithValue("@prmstrNombreusuario", usuario.Nombreusuario);
                cmd.Parameters.AddWithValue("@prmintResidenteID", usuario.Residente.ResidenteID);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Inserta = true;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return Inserta;
        }

        public Boolean EditarUsuario(entUsuario usuario)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_EDITARUSUARIO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintUsuarioID", usuario.UsuarioID);
                cmd.Parameters.AddWithValue("@prmstrContrasenausuario", usuario.Contrasenausuario);
                cmd.Parameters.AddWithValue("@prmblEstadousuario", usuario.Estadousuario);
                cmd.Parameters.AddWithValue("@prmstrNombreusuario", usuario.Nombreusuario);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >= 0)
                {
                    edita = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return edita;
        }

        public Boolean EliminarUsuario(int UsuarioID)
        {
            SqlCommand cmd = null;
            Boolean elimina = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_ELIMINARUSUARIO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintUsuarioID", UsuarioID);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >= 0)
                {
                    elimina = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return elimina;
        }

        public entUsuario ObtenerUsuario(int UsuarioID)
        {
            SqlCommand cmd = null;
            entUsuario usuario = new entUsuario();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_OBTENERUSUARIO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintUsuarioID", UsuarioID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usuario.UsuarioID = Convert.ToInt16(dr["UsuarioID"]);
                    usuario.Nombreusuario = dr["Nombreusuario"].ToString();
                    usuario.Contrasenausuario = dr["Contrasenausuario"].ToString();
                    usuario.Estadousuario = Convert.ToBoolean(dr["Estadousuario"]);
                    usuario.Residente = datResidente.Instancia.ObtenerResidente(Convert.ToInt16(dr["ResidenteID"]));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return usuario;
        }

        public entUsuario VerificarNombreusuarioContrasenausuario(string Nombreusuario, string Contrasenausuario)
        {
            SqlCommand cmd = null;
            entUsuario usuario = new entUsuario();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_VERIFICARNOMBREUSUARIOYCONTRASENA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrNombreusuario", Nombreusuario);
                cmd.Parameters.AddWithValue("@prmstrContrasenausuario", Contrasenausuario);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    usuario.UsuarioID = Convert.ToInt16(dr["UsuarioID"]);
                    usuario.Nombreusuario = dr["Nombreusuario"].ToString();
                    usuario.Contrasenausuario = dr["Contrasenausuario"].ToString();
                    usuario.Estadousuario = Convert.ToBoolean(dr["Estadousuario"]);
                    usuario.Residente = datResidente.Instancia.ObtenerResidente(Convert.ToInt16(dr["ResidenteID"]));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return usuario;
        }
        #endregion
    }
}
