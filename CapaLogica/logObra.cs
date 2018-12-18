using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaAccesoDatos;

namespace CapaLogica
{
    public class logObra
    {
        #region singleton
        private static readonly logObra _instancia = new logObra();
        public static logObra Instancia
        {
            get { return logObra._instancia; }
        }
        #endregion

        #region Metodos
        public List<entObra> ListarObras()
        {
            try
            {
                return datObra.Instancia.ListarObras();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public entObra ObtenerObra(int ObraID)
        {
            try
            {
                return datObra.Instancia.ObtenerObra(ObraID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean InsertarObra(entObra Obra)
        {
            try
            {
                return datObra.Instancia.InsertarObra(Obra);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EditarObra(entObra Obra)
        {
            try
            {
                return datObra.Instancia.EditarObra(Obra);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EliminarObra(int ObraID)
        {
            try
            {
                return datObra.Instancia.EliminarObra(ObraID);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
