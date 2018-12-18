using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaAccesoDatos;

namespace CapaLogica
{
    public class logProgramaActividad
    {
        #region singleton
        private static readonly logProgramaActividad _instancia = new logProgramaActividad();
        public static logProgramaActividad Instancia
        {
            get { return logProgramaActividad._instancia; }
        }
        #endregion

        #region Metodos
        public List<entProgramaActividad> ListarActividadesDePrograma(int ProgramaID)
        {
            try
            {
                return datProgramaActividad.Instancia.ListarActividadesDePrograma(ProgramaID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<entProgramaActividad> ListarActividadesNoDentroDePrograma(int ProgramaID)
        {
            try
            {
                return datProgramaActividad.Instancia.ListarActividadesNoDentroDePrograma(ProgramaID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<entProgramaActividad> ReportarTotalProgramasActividades(int ObraID, int ResidenteID)
        {
            try
            {
                return datProgramaActividad.Instancia.ReportarTotalProgramasActividades(ObraID, ResidenteID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertarActividadAPrograma(entProgramaActividad programaActividad)
        {
            try
            {
                return datProgramaActividad.Instancia.InsertarActividadAPrograma(programaActividad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EliminarActividadDePrograma(int ProgramaID, int ActividadID)
        {
            try
            {
                return datProgramaActividad.Instancia.EliminarActividadDePrograma(ProgramaID, ActividadID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}
