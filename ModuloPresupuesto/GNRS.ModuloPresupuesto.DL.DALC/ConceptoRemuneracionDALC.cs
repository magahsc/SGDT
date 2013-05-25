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
                         where s.mostrar_boleta == 1 && s.columna_boleta == tipo
                         select s).ToList();
                return lista;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean insertarConceptoPersona(CONCEPTO_POR_PERSONA obj)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                context.CONCEPTO_POR_PERSONA.AddObject(obj);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public CONCEPTO_REMUNERACION obtenerConceptoPersonaXID(int id)
        {
            try
            {

                CONCEPTO_REMUNERACION obj = new CONCEPTO_REMUNERACION();
                var context = new PresupuestoDBEntities();
                obj = (from a in context.CONCEPTO_REMUNERACION
                       where a.id_concepto == id
                       select a).First();


                return obj;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
