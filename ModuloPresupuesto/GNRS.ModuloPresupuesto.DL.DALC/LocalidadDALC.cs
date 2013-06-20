using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GNRS.ModuloPresupuesto.DL.DALC
{
    public class LocalidadDALC
    {
        public List<LOCALIDAD> listarLocalidades()
        {
            try
            {
                List<LOCALIDAD> lista = new List<LOCALIDAD>();
                var context = new PresupuestoDBEntities();
                lista = context.LOCALIDAD.ToList();
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public LOCALIDAD obtenerLocalidadXCodigo(int codigoLocalidad)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                LOCALIDAD localidad = new LOCALIDAD();

                localidad = (from l in context.LOCALIDAD
                             where l.id_localidad == codigoLocalidad
                             select l).First();

                return localidad;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
