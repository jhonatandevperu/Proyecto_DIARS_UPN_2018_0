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
    public class datActividad
    {
        #region singleton
        private static readonly datActividad _instancia = new datActividad();
        public static datActividad Instancia
        {
            get { return datActividad._instancia; }
        }
        #endregion

        #region Metodos
        public List<entActividad> ListarActividades()
        {
            SqlCommand cmd = null;
            List<entActividad> lista = new List<entActividad>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_LISTARACTIVIDADES", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entActividad actividad = new entActividad();
                    actividad.ActividadID = Convert.ToInt16(dr["ActividadID"]);
                    actividad.Nombreactividad = dr["Nombreactividad"].ToString();
                    actividad.Prioridadactividad = dr["Prioridadactividad"].ToString();
                    actividad.Fechainicioactividad = Convert.ToDateTime(dr["Fechainicioactividad"]);
                    actividad.Fechafinactividad = Convert.ToDateTime(dr["Fechafinactividad"]);
                    actividad.Totaloperariosactividad = Convert.ToInt16(dr["Totaloperariosactividad"]);
                    lista.Add(actividad);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public Boolean InsertarActividad(entActividad actividad)
        {
            SqlCommand cmd = null;
            Boolean Inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_INSERTARACTIVIDAD", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrNombreactividad", actividad.Nombreactividad);
                cmd.Parameters.AddWithValue("@prmstrPrioridadactividad", actividad.Prioridadactividad);
                cmd.Parameters.AddWithValue("@prmdtFechainicioactividad", actividad.Fechainicioactividad);
                cmd.Parameters.AddWithValue("@prmdtFechafinactividad", actividad.Fechafinactividad);
                cmd.Parameters.AddWithValue("@prmintTotaloperariosactividad", actividad.Totaloperariosactividad);
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

        public Boolean EditarActividad(entActividad actividad)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_EDITARACTIVIDAD", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintActividadID", actividad.ActividadID);
                cmd.Parameters.AddWithValue("@prmstrNombreactividad", actividad.Nombreactividad);
                cmd.Parameters.AddWithValue("@prmstrPrioridadactividad", actividad.Prioridadactividad);
                cmd.Parameters.AddWithValue("@prmdtFechainicioactividad", actividad.Fechainicioactividad);
                cmd.Parameters.AddWithValue("@prmdtFechafinactividad", actividad.Fechafinactividad);
                cmd.Parameters.AddWithValue("@prmintTotaloperariosactividad", actividad.Totaloperariosactividad);
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

        public Boolean EliminarActividad(int ActividadID)
        {
            SqlCommand cmd = null;
            Boolean elimina = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_ELIMINARACTIVIDAD", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintActividadID", ActividadID);
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

        public entActividad ObtenerActividad(int ActividadID)
        {
            SqlCommand cmd = null;
            entActividad actividad = new entActividad();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_OBTENERACTIVIDAD", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintActividadID", ActividadID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    actividad.ActividadID = Convert.ToInt16(dr["ActividadID"]);
                    actividad.Nombreactividad = dr["Nombreactividad"].ToString();
                    actividad.Prioridadactividad = dr["Prioridadactividad"].ToString();
                    actividad.Fechainicioactividad = Convert.ToDateTime(dr["Fechainicioactividad"]);
                    actividad.Fechafinactividad = Convert.ToDateTime(dr["Fechafinactividad"]);
                    actividad.Totaloperariosactividad = Convert.ToInt16(dr["Totaloperariosactividad"]);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return actividad;
        }
        #endregion
    }
}
