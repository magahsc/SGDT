using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GNRS.ModuloPresupuesto.DL.DALC
{
    public class CargoDALC
    {
        public List<CARGO_PERSONAL> listarCargos()
        {
            try
            {
                List<CARGO_PERSONAL> lista = new List<CARGO_PERSONAL>();
                var context = new PresupuestoDBEntities();
                lista = context.CARGO_PERSONAL.ToList();
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public List<CARGO_PERSONAL> listarCargosXSeccion(int codigoSeccion)
        {
            try
            {
                List<CARGO_PERSONAL> lista = new List<CARGO_PERSONAL>();
                var context = new PresupuestoDBEntities();
                lista = (from c in context.CARGO_PERSONAL
                         where c.id_seccion == codigoSeccion
                         select c).ToList();                   
                    
                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
