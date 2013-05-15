using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using GNRS.ModuloPresupuesto.BL.BE;

namespace GNRS.ModuloPresupuesto.DL.DALC
{
    public class PersonaDALC
    {
        public Boolean insertarPersonalProyectado(PERSONA persona)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                context.PERSONA.AddObject(persona);
                persona.estado_persona = "P";

                DateTime now = DateTime.Now;
                persona.fecha_creacion = now;
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<PersonaBE> listarPersonasProyectado(int codigolocalidad, int codigoarea, int codigoseccion)
        {
            try
            {
                List<PersonaBE> lista = new List<PersonaBE>();
                PersonaBE objpersonaBE;
                var context = new PresupuestoDBEntities();
                var prueba = (from p in context.PERSONA
                              join s in context.SECCION on p.id_seccion equals s.id_seccion
                              join a in context.AREA on s.id_area equals a.id_area
                              join c in context.CARGO_PERSONAL on p.id_cargo equals c.id_cargo
                              where p.id_localidad == codigolocalidad && p.id_seccion == codigoseccion && a.id_area == codigoarea
                              select new { p.id_persona, p.nombres_persona, p.apellido_paterno, p.apellido_materno, c.nombre_cargo }).ToList();

                foreach (var item in prueba)
                {
                    String nombre = item.nombres_persona + " " + item.apellido_paterno + " " + item.apellido_materno;
                    objpersonaBE = new PersonaBE();
                    objpersonaBE.Id_persona = item.id_persona;
                    objpersonaBE.Nombre_persona = nombre;
                    objpersonaBE.Cargo_persona = item.nombre_cargo;
                    lista.Add(objpersonaBE);
                }

                return lista;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<PERSONA> obtenerPersonasXLocalidadSeccionCargo(int codigolocalidad, int codigoarea, int codigoseccion, int codigoCargo)
        {
            try
            {
                List<PERSONA> lista = new List<PERSONA>();
                var context = new PresupuestoDBEntities();
                lista = (from p in context.PERSONA
                         // orderby p.nombres_persona descending
                         // where (p.id_localidad == codigolocalidad && p.id_seccion == codigoseccion && p.id_cargo == codigoCargo)
                         where p.id_localidad == codigolocalidad
                         select p).ToList();

                //foreach (var item in prueba)
                //{
                //    lista.Add(item);
                //}

                return lista;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<PRESUPUESTO_CAPACITACION_POR_PERSONAL> obtenerCapacitacionPersonaXCodigo(int idpresupuestocapacitacion)
        {
            try
            {
                List<PRESUPUESTO_CAPACITACION_POR_PERSONAL> lista = new List<PRESUPUESTO_CAPACITACION_POR_PERSONAL>();
                var context = new PresupuestoDBEntities();
                lista = (from p in context.PRESUPUESTO_CAPACITACION_POR_PERSONAL
                         where p.id_presupuesto_capacitacion == idpresupuestocapacitacion
                         select p).ToList();

                return lista;

            }
            catch (Exception ex)
            {
                throw;
            }

        }



        public List<PERSONA> listarPersonas()
        {
            try
            {
                List<PERSONA> lista = new List<PERSONA>();
                var context = new PresupuestoDBEntities();
                lista = context.PERSONA.ToList();
                return lista;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
