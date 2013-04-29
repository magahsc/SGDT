using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GNRS.ModuloPresupuesto.DL.DALC
{
    public class InstitutoDALC
    {
        public List<INSTITUCION> listarinstituciones()
        {
            try
            {
                List<INSTITUCION> lista = new List<INSTITUCION>();
                var context = new PresupuestoDBEntities();
                lista = context.INSTITUCION.ToList();
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
