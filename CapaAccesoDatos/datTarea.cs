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
    public class datTarea
    {
        #region singleton
        private static readonly datTarea _instancia = new datTarea();
        public static datTarea Instancia
        {
            get { return datTarea._instancia; }
        }
        #endregion

        #region Metodos
        public List<entTarea> ListarTareas()
        {
            SqlCommand cmd = null;
            List<entTarea> lista = new List<entTarea>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_LISTARTAREAS", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entTarea tarea = new entTarea();
                    tarea.TareaID = Convert.ToInt16(dr["TareaID"]);
                    tarea.Nombretarea = dr["Nombretarea"].ToString();
                    tarea.Duraciontarea = Convert.ToInt16(dr["Duraciontarea"]);
                    tarea.Numerooperariostarea = Convert.ToInt16(dr["Numerooperariostarea"]);
                    lista.Add(tarea);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public Boolean InsertarTarea(entTarea tarea)
        {
            SqlCommand cmd = null;
            Boolean Inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_INSERTARTAREA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrNombretarea", tarea.Nombretarea);
                cmd.Parameters.AddWithValue("@prmintNumerooperariostarea", tarea.Numerooperariostarea);
                cmd.Parameters.AddWithValue("@prmintDuraciontarea", tarea.Duraciontarea);
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

        public Boolean EditarTarea(entTarea tarea)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_EDITARTAREA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintTareaID", tarea.TareaID);
                cmd.Parameters.AddWithValue("@prmstrNombretarea", tarea.Nombretarea);
                cmd.Parameters.AddWithValue("@prmintNumerooperariostarea", tarea.Numerooperariostarea);
                cmd.Parameters.AddWithValue("@prmintDuraciontarea", tarea.Duraciontarea);
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

        public Boolean EliminarTarea(int TareaID)
        {
            SqlCommand cmd = null;
            Boolean elimina = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_ELIMINARTAREA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
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

        public entTarea ObtenerTarea(int TareaID)
        {
            SqlCommand cmd = null;
            entTarea tarea = new entTarea();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_OBTENERTAREA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintTareaID", TareaID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tarea.TareaID = Convert.ToInt16(dr["TareaID"]);
                    tarea.Nombretarea = dr["Nombretarea"].ToString();
                    tarea.Duraciontarea = Convert.ToInt16(dr["Duraciontarea"]);
                    tarea.Numerooperariostarea = Convert.ToInt16(dr["Numerooperariostarea"]);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return tarea;
        }

        #endregion
    }
}
