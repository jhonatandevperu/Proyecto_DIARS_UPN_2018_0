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
    public class datResidente
    {
        #region singleton
        private static readonly datResidente _instancia = new datResidente();
        public static datResidente Instancia
        {
            get { return datResidente._instancia; }
        }
        #endregion

        #region Metodos
        public List<entResidente> ListarResidentes()
        {
            SqlCommand cmd = null;
            List<entResidente> lista = new List<entResidente>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_LISTARRESIDENTES", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entResidente residente = new entResidente();
                    residente.ResidenteID = Convert.ToInt16(dr["ResidenteID"]);
                    residente.Nombresresidente = dr["Nombresresidente"].ToString();
                    residente.Apellidosresidente = dr["Apellidosresidente"].ToString();
                    residente.Direccionresidente = dr["Direccionresidente"].ToString();
                    residente.Telefonoresidente = dr["Telefonoresidente"].ToString();
                    lista.Add(residente);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public List<entResidente> ListarResidentesSinUsuarios()
        {
            SqlCommand cmd = null;
            List<entResidente> lista = new List<entResidente>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_LISTARRESIDENTESSINUSUARIOS", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entResidente residente = new entResidente();
                    residente.ResidenteID = Convert.ToInt16(dr["ResidenteID"]);
                    residente.Nombresresidente = dr["Nombresresidente"].ToString();
                    residente.Apellidosresidente = dr["Apellidosresidente"].ToString();
                    residente.Direccionresidente = dr["Direccionresidente"].ToString();
                    residente.Telefonoresidente = dr["Telefonoresidente"].ToString();
                    lista.Add(residente);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public Boolean InsertarResidente(entResidente Residente)
        {
            SqlCommand cmd = null;
            Boolean Inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_INSERTARRESIDENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrApellidosresidente", Residente.Apellidosresidente);
                cmd.Parameters.AddWithValue("@prmstrDireccionresidente", Residente.Direccionresidente);
                cmd.Parameters.AddWithValue("@prmstrNombresresidente", Residente.Nombresresidente);
                cmd.Parameters.AddWithValue("@prmstrTelefonoresidente", Residente.Telefonoresidente);
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

        public Boolean EditarResidente(entResidente Residente)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_EDITARRESIDENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintResidenteID", Residente.ResidenteID);
                cmd.Parameters.AddWithValue("@prmstrApellidosresidente", Residente.Apellidosresidente);
                cmd.Parameters.AddWithValue("@prmstrDireccionresidente", Residente.Direccionresidente);
                cmd.Parameters.AddWithValue("@prmstrNombresresidente", Residente.Nombresresidente);
                cmd.Parameters.AddWithValue("@prmstrTelefonoresidente", Residente.Telefonoresidente);
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

        public Boolean EliminarResidente(int ResidenteID)
        {
            SqlCommand cmd = null;
            Boolean elimina = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_ELIMINARRESIDENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintResidenteID", ResidenteID);
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


        public entResidente ObtenerResidente(int ResidenteID)
        {
            SqlCommand cmd = null;
            entResidente residente = new entResidente();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_OBTENERRESIDENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintResidenteID", ResidenteID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    residente.ResidenteID = Convert.ToInt16(dr["ResidenteID"]);
                    residente.Nombresresidente = dr["Nombresresidente"].ToString();
                    residente.Apellidosresidente = dr["Apellidosresidente"].ToString();
                    residente.Direccionresidente = dr["Direccionresidente"].ToString();
                    residente.Telefonoresidente = dr["Telefonoresidente"].ToString();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return residente;
        }
        #endregion
    }
}
