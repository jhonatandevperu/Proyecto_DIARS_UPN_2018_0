using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaAccesoDatos;

namespace CapaLogica
{
    public class logResidente
    {
        #region singleton
        private static readonly logResidente _instancia = new logResidente();
        public static logResidente Instancia
        {
            get { return logResidente._instancia; }
        }
        #endregion

        #region Metodos
        public List<entResidente> ListarResidentes()
        {
            try
            {
                return datResidente.Instancia.ListarResidentes();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<entResidente> ListarResidentesSinUsuarios()
        {
            try
            {
                return datResidente.Instancia.ListarResidentes();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public entResidente ObtenerResidente(int ResidenteID)
        {
            try
            {
                return datResidente.Instancia.ObtenerResidente(ResidenteID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertarResidente(entResidente Residente)
        {
            try
            {
                return datResidente.Instancia.InsertarResidente(Residente);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EditarResidente(entResidente Residente)
        {
            try
            {
                return datResidente.Instancia.EditarResidente(Residente);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EliminarResidente(int ProgramaID)
        {
            try
            {
                return datResidente.Instancia.EliminarResidente(ProgramaID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
