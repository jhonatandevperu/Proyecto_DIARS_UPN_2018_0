using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaAccesoDatos;

namespace CapaLogica
{
    public class logActividad
    {
        #region singleton
        private static readonly logActividad _instancia = new logActividad();
        public static logActividad Instancia
        {
            get { return logActividad._instancia; }
        }
        #endregion

        #region Metodos
        public List<entActividad> ListarActividades()
        {
            try
            {
                return datActividad.Instancia.ListarActividades();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public entActividad ObtenerActividad(int ActividadID)
        {
            try
            {
                return datActividad.Instancia.ObtenerActividad(ActividadID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertarActividad(entActividad Actividad)
        {
            try
            {
                return datActividad.Instancia.InsertarActividad(Actividad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EditarActividad(entActividad Actividad)
        {
            try
            {
                return datActividad.Instancia.EditarActividad(Actividad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EliminarActividad(int ActividadID)
        {
            try
            {
                return datActividad.Instancia.EliminarActividad(ActividadID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
