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

        public INSTITUCION obtenerInstitucionXcodigoCurso(int codigoCurso)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                INSTITUCION institucion = new INSTITUCION();

                institucion = (from i in context.INSTITUCION
                               join c in context.CURSO on i.id_institucion equals c.id_institucion
                               where c.id_curso == codigoCurso
                               select i).First();

                return institucion;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
