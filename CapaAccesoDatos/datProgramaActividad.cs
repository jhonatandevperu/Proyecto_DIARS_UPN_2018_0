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
    public class datProgramaActividad
    {
        #region singleton
        private static readonly datProgramaActividad _instancia = new datProgramaActividad();
        public static datProgramaActividad Instancia
        {
            get { return datProgramaActividad._instancia; }
        }
        #endregion

        #region Metodos

        public List<entProgramaActividad> ListarActividadesDePrograma(int ProgramaID)
        {
            SqlCommand cmd = null;
            List<entProgramaActividad> lista = new List<entProgramaActividad>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_LISTARACTIVIDADESDEPROGRAMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintProgramaID", ProgramaID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProgramaActividad programaActividad = new entProgramaActividad();
                    programaActividad.Actividad = datActividad.Instancia.ObtenerActividad(Convert.ToInt16(dr["ActividadID"]));
                    programaActividad.Programa = datPrograma.Instancia.ObtenerPrograma(Convert.ToInt16(dr["ProgramaID"]));
                    lista.Add(programaActividad);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public List<entProgramaActividad> ListarActividadesNoDentroDePrograma(int ProgramaID)
        {
            SqlCommand cmd = null;
            List<entProgramaActividad> lista = new List<entProgramaActividad>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_LISTARAACTIVIDADESNODENTRODEPROGRAMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintProgramaID", ProgramaID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProgramaActividad programaActividad = new entProgramaActividad();
                    programaActividad.Actividad = datActividad.Instancia.ObtenerActividad(Convert.ToInt16(dr["ActividadID"]));
                    lista.Add(programaActividad);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public List<entProgramaActividad> ReportarTotalProgramasActividades(int ObraID, int ResidenteID)
        {
            SqlCommand cmd = null;
            List<entProgramaActividad> lista = new List<entProgramaActividad>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_LISTARTOTALPROGRAMASACTIVIDADES", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintObraID", ObraID);
                cmd.Parameters.AddWithValue("@prmintResidenteID", ResidenteID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entProgramaActividad programaActividad = new entProgramaActividad();
                    programaActividad.Actividad = datActividad.Instancia.ObtenerActividad(Convert.ToInt16(dr["ActividadID"]));
                    programaActividad.Programa = datPrograma.Instancia.ObtenerPrograma(Convert.ToInt16(dr["ProgramaID"]));
                    lista.Add(programaActividad);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public Boolean InsertarActividadAPrograma(entProgramaActividad programaActividad)
        {
            SqlCommand cmd = null;
            Boolean Inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_INSERTARACTIVIDADAPROGRAMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintProgramaID", programaActividad.Programa.ProgramaID);
                cmd.Parameters.AddWithValue("@prmintActividadID", programaActividad.Actividad.ActividadID);
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


        public Boolean EliminarActividadDePrograma(int ProgramaID, int ActividadID)
        {
            SqlCommand cmd = null;
            Boolean elimina = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_ELIMINARACTIVIDADDEPROGRAMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintProgramaID", ProgramaID);
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

        #endregion
    }
}
