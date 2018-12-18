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
    public class datPrograma
    {
        #region singleton
        private static readonly datPrograma _instancia = new datPrograma();
        public static datPrograma Instancia
        {
            get { return datPrograma._instancia; }
        }
        #endregion

        #region Metodos

        public List<entPrograma> ListarProgramasDeObrayDeResidente(int ObraID, int ResidenteID)
        {
            SqlCommand cmd = null;
            List<entPrograma> lista = new List<entPrograma>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_LISTARPROGRAMASDEOBRAYDERESIDENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintObraID", ObraID);
                cmd.Parameters.AddWithValue("@prmintResidenteID", ResidenteID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entPrograma programa = new entPrograma();
                    programa.ProgramaID = Convert.ToInt16(dr["ProgramaID"]);
                    programa.Nombreprograma = dr["Nombreprograma"].ToString();
                    programa.Descripcionprograma = dr["Descripcionprograma"].ToString();
                    programa.Coordinadorprograma = dr["Coordinadorprograma"].ToString();
                    programa.Fechainicioprograma = Convert.ToDateTime(dr["Fechainicioprograma"]);
                    programa.Fechafinprograma = Convert.ToDateTime(dr["Fechafinprograma"]);
                    programa.Obra = datObra.Instancia.ObtenerObra(Convert.ToInt16(dr["ObraID"]));
                    programa.Residente = datResidente.Instancia.ObtenerResidente(Convert.ToInt16(dr["ResidenteID"]));
                    lista.Add(programa);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public List<entPrograma> ListarProgramasDeObra(int ObraID)
        {
            SqlCommand cmd = null;
            List<entPrograma> lista = new List<entPrograma>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_LISTARPROGRAMASDEOBRA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintObraID", ObraID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entPrograma programa = new entPrograma();
                    programa.ProgramaID = Convert.ToInt16(dr["ProgramaID"]);
                    programa.Nombreprograma = dr["Nombreprograma"].ToString();
                    programa.Descripcionprograma = dr["Descripcionprograma"].ToString();
                    programa.Coordinadorprograma = dr["Coordinadorprograma"].ToString();
                    programa.Fechainicioprograma = Convert.ToDateTime(dr["Fechainicioprograma"]);
                    programa.Fechafinprograma = Convert.ToDateTime(dr["Fechafinprograma"]);
                    programa.Obra = datObra.Instancia.ObtenerObra(Convert.ToInt16(dr["ObraID"]));
                    programa.Residente = datResidente.Instancia.ObtenerResidente(Convert.ToInt16(dr["ResidenteID"]));
                    lista.Add(programa);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public List<entPrograma> ListarProgramas()
        {
            SqlCommand cmd = null;
            List<entPrograma> lista = new List<entPrograma>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_LISTARPROGRAMAS", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entPrograma programa = new entPrograma();
                    programa.ProgramaID = Convert.ToInt16(dr["ProgramaID"]);
                    programa.Nombreprograma = dr["Nombreprograma"].ToString();
                    programa.Descripcionprograma = dr["Descripcionprograma"].ToString();
                    programa.Coordinadorprograma = dr["Coordinadorprograma"].ToString();
                    programa.Fechainicioprograma = Convert.ToDateTime(dr["Fechainicioprograma"]);
                    programa.Fechafinprograma = Convert.ToDateTime(dr["Fechafinprograma"]);
                    programa.Obra = datObra.Instancia.ObtenerObra(Convert.ToInt16(dr["ObraID"]));
                    programa.Residente = datResidente.Instancia.ObtenerResidente(Convert.ToInt16(dr["ResidenteID"]));
                    lista.Add(programa);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public Boolean InsertarPrograma(entPrograma programa)
        {
            SqlCommand cmd = null;
            Boolean Inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_INSERTARPROGRAMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrCoordinadorprograma", programa.Coordinadorprograma);
                cmd.Parameters.AddWithValue("@prmstrDescripcionprograma", programa.Descripcionprograma);
                cmd.Parameters.AddWithValue("@prmdtFechainicioprograma", programa.Fechainicioprograma);
                cmd.Parameters.AddWithValue("@prmdtFechafinprograma", programa.Fechafinprograma);
                cmd.Parameters.AddWithValue("@prmstrNombreprograma", programa.Nombreprograma);
                cmd.Parameters.AddWithValue("@prmintObraID", programa.Obra.ObraID);
                cmd.Parameters.AddWithValue("@prmintResidenteID", programa.Residente.ResidenteID);
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

        public Boolean EditarPrograma(entPrograma programa)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_EDITARPROGRAMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintProgramaID", programa.ProgramaID);
                cmd.Parameters.AddWithValue("@prmstrCoordinadorprograma", programa.Coordinadorprograma);
                cmd.Parameters.AddWithValue("@prmstrDescripcionprograma", programa.Descripcionprograma);
                cmd.Parameters.AddWithValue("@prmdtFechainicioprograma", programa.Fechainicioprograma);
                cmd.Parameters.AddWithValue("@prmdtFechafinprograma", programa.Fechafinprograma);
                cmd.Parameters.AddWithValue("@prmstrNombreprograma", programa.Nombreprograma);
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

        public Boolean EliminarPrograma(int ProgramaID)
        {
            SqlCommand cmd = null;
            Boolean elimina = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_ELIMINARPROGRAMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintProgramaID", ProgramaID);
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

        public entPrograma ObtenerPrograma(int ProgramaID)
        {
            SqlCommand cmd = null;
            entPrograma programa = new entPrograma();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("SP_OBTENERPROGRAMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintProgramaID", ProgramaID);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    programa.ProgramaID = Convert.ToInt16(dr["ProgramaID"]);
                    programa.Nombreprograma = dr["Nombreprograma"].ToString();
                    programa.Descripcionprograma = dr["Descripcionprograma"].ToString();
                    programa.Coordinadorprograma = dr["Coordinadorprograma"].ToString();
                    programa.Fechainicioprograma = Convert.ToDateTime(dr["Fechainicioprograma"]);
                    programa.Fechafinprograma = Convert.ToDateTime(dr["Fechafinprograma"]);
                    programa.Obra = datObra.Instancia.ObtenerObra(Convert.ToInt16(dr["ObraID"]));
                    programa.Residente = datResidente.Instancia.ObtenerResidente(Convert.ToInt16(dr["ResidenteID"]));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return programa;
        }

        #endregion
    }
}
