using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GNRS.ModuloPresupuesto.DL.DALC
{
    public class ConceptoPersonaDALC
    {
        public Boolean editarMontoCostoEmpresa(int idPersonsa, int idConcepto, float montoCostoEmpresa)
        {
            try
            {


                var context = new PresupuestoDBEntities();
                CONCEPTO_POR_PERSONA obj = (from a in context.CONCEPTO_POR_PERSONA
                                            where a.id_persona == idPersonsa && a.id_concepto == idConcepto
                                            select a).First();

                obj.monto_costo_empresa = montoCostoEmpresa;
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public List<CONCEPTO_POR_PERSONA> listarConceptosXPersona(int idPersonsa)
        {
            try
            {
                List<CONCEPTO_POR_PERSONA> lista = new List<CONCEPTO_POR_PERSONA>();

                var context = new PresupuestoDBEntities();
                lista = (from a in context.CONCEPTO_POR_PERSONA
                         where a.id_persona == idPersonsa
                         select a).ToList();


                return lista;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void eliminarConceptosXIDPersona(int idPersonsa)
        {
            try
            {
                List<CONCEPTO_POR_PERSONA> lista = new List<CONCEPTO_POR_PERSONA>();

                var context = new PresupuestoDBEntities();
                context.CONCEPTO_POR_PERSONA.Where(a => a.id_persona == idPersonsa).ToList().ForEach(context.CONCEPTO_POR_PERSONA.DeleteObject);

                context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
