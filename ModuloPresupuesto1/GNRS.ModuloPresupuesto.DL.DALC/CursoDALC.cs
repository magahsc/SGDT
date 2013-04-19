﻿using System;
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
                         where s.id_curso == codigoInstituto
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
    }
}
