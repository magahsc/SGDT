using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GNRS.ModuloPresupuesto.DL.DALC
{
    public class ConceptoRemuneracionDALC
    {
        public List<CONCEPTO_REMUNERACION> listaConceptoRemuneracionXTipo(int tipo)
        {
            try
            {
                List<CONCEPTO_REMUNERACION> lista = new List<CONCEPTO_REMUNERACION>();
                var context = new PresupuestoDBEntities();
                lista = (from s in context.CONCEPTO_REMUNERACION
                         where s.mostrar_boleta==true && s.columna_boleta==tipo
                         select s).ToList();
                return lista;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
