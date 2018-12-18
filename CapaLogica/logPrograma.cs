using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaAccesoDatos;

namespace CapaLogica
{
    public class logPrograma
    {
        #region singleton
        private static readonly logPrograma _instancia = new logPrograma();
        public static logPrograma Instancia
        {
            get { return logPrograma._instancia; }
        }
        #endregion

        #region Metodos

        public List<entPrograma> ListarProgramasDeObrayDeResidente(int ObraID, int ResidenteID)
        {
            try
            {
                return datPrograma.Instancia.ListarProgramasDeObrayDeResidente(ObraID, ResidenteID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<entPrograma> ListarProgramasDeObra(int ObraID)
        {
            try
            {
                return datPrograma.Instancia.ListarProgramasDeObra(ObraID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<entPrograma> ListarProgramas()
        {
            try
            {
                return datPrograma.Instancia.ListarProgramas();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public entPrograma ObtenerPrograma(int ProgramaID)
        {
            try
            {
                return datPrograma.Instancia.ObtenerPrograma(ProgramaID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertarPrograma(entPrograma Programa)
        {
            try
            {
                return datPrograma.Instancia.InsertarPrograma(Programa);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EditarPrograma(entPrograma Programa)
        {
            try
            {
                return datPrograma.Instancia.EditarPrograma(Programa);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EliminarPrograma(int ProgramaID)
        {
            try
            {
                return datPrograma.Instancia.EliminarPrograma(ProgramaID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
