using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaAccesoDatos;

namespace CapaLogica
{
    public class logTarea
    {
        #region singleton
        private static readonly logTarea _instancia = new logTarea();
        public static logTarea Instancia
        {
            get { return logTarea._instancia; }
        }
        #endregion

        #region Metodos
        public List<entTarea> ListarTareas()
        {
            try
            {
                return datTarea.Instancia.ListarTareas();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public entTarea ObtenerTarea(int TareaID)
        {
            try
            {
                return datTarea.Instancia.ObtenerTarea(TareaID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertarTarea(entTarea Tarea)
        {
            try
            {
                return datTarea.Instancia.InsertarTarea(Tarea);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EditarTarea(entTarea Tarea)
        {
            try
            {
                return datTarea.Instancia.EditarTarea(Tarea);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EliminarTarea(int TareaID)
        {
            try
            {
                return datTarea.Instancia.EliminarTarea(TareaID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
