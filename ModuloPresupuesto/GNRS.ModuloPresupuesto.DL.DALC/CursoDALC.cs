using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GNRS.ModuloPresupuesto.DL.DALC
{
    public class CursoDALC
    {
        public List<CURSO> listaCursoXInstitucion(int codigoInstituto)
        {
            try
            {
                List<CURSO> lista = new List<CURSO>();
                var context = new PresupuestoDBEntities();
                lista = (from s in context.CURSO
                         where s.id_institucion == codigoInstituto
                         select s).ToList();
                return lista;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<CURSO> listarCurso()
        {
            try
            {
                List<CURSO> lista = new List<CURSO>();
                var context = new PresupuestoDBEntities();
                lista = context.CURSO.ToList();
                return lista;


            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CURSO obtenerCurso(int codigoCurso)
        {
            try
            {
                CURSO curso = new CURSO();
                var context = new PresupuestoDBEntities();

                curso = (from c in context.CURSO
                         where c.id_curso == codigoCurso
                         select c).First();

                return curso;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
