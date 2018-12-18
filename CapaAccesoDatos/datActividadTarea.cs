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
    public class datActividadTarea
    {
        #region singleton
        private static readonly datActividadTarea _instancia = new datActividadTarea();
        public static datActividadTarea Instancia
        {
            get { return datActividadTarea._instancia; }
        }
        #endregion

        #region Metodos
        public List<entActividadTarea> ListarTareasDeActividad(int ActividadID)
        {
            SqlCommand cmd = null;
            List<entActividadTarea> lista = new List<entActividadTarea>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_LISTARTAREASDEACTIVIDAD", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintActividadID", ActividadID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entActividadTarea actividadTarea = new entActividadTarea();
                    actividadTarea.Actividad = datActividad.Instancia.ObtenerActividad(Convert.ToInt16(dr["ActividadID"]));
                    actividadTarea.Tarea = datTarea.Instancia.ObtenerTarea(Convert.ToInt16(dr["TareaID"]));
                    lista.Add(actividadTarea);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public List<entActividadTarea> ListarTareasNoDentroDeActividad(int ActividadID)
        {
            SqlCommand cmd = null;
            List<entActividadTarea> lista = new List<entActividadTarea>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_LISTARATAREASNODENTRODEACTIVIDAD", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintActividadID", ActividadID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entActividadTarea actividadTarea = new entActividadTarea();
                    actividadTarea.Actividad = datActividad.Instancia.ObtenerActividad(ActividadID);
                    actividadTarea.Tarea = datTarea.Instancia.ObtenerTarea(Convert.ToInt16(dr["TareaID"]));
                    lista.Add(actividadTarea);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public Boolean InsertarTareaAActividad(entActividadTarea actividadTarea)
        {
            SqlCommand cmd = null;
            Boolean Inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_INSERTARTAREAAACTIVIDAD", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintActividadID", actividadTarea.Actividad.ActividadID);
                cmd.Parameters.AddWithValue("@prmintTareaID", actividadTarea.Tarea.TareaID);
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

        public Boolean EliminarTareaDeActividad(int ActividadID, int TareaID)
        {
            SqlCommand cmd = null;
            Boolean elimina = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_ELIMINARTAREADEACTIVIDAD", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintActividadID", ActividadID);
                cmd.Parameters.AddWithValue("@prmintTareaID", TareaID);
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

        #endregion
    }
}
