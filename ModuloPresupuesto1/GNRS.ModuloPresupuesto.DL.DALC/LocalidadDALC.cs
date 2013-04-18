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
                lista=context.LOCALIDAD.ToList();                
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
