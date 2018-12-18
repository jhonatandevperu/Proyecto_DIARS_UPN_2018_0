using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaAccesoDatos;

namespace CapaLogica
{
    public class logActividadTarea
    {
        #region singleton
        private static readonly logActividadTarea _instancia = new logActividadTarea();
        public static logActividadTarea Instancia
        {
            get { return logActividadTarea._instancia; }
        }
        #endregion


        #region Metodos

        public List<entActividadTarea> ListarTareasDeActividad(int ActividadID)
        {
            try
            {
                return datActividadTarea.Instancia.ListarTareasDeActividad(ActividadID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<entActividadTarea> ListarTareasNoDentroDeActividad(int ActividadID)
        {
            try
            {
                return datActividadTarea.Instancia.ListarTareasNoDentroDeActividad(ActividadID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertarTareaAActividad(entActividadTarea actividadTarea)
        {
            try
            {
                return datActividadTarea.Instancia.InsertarTareaAActividad(actividadTarea);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Boolean EliminarTareaDeActividad(int ActividadID, int TareaID)
        {
            try
            {
                return datActividadTarea.Instancia.EliminarTareaDeActividad(ActividadID, TareaID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
