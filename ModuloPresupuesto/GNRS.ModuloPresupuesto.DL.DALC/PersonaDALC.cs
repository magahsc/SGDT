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
                persona.apellido_materno = "";
                persona.apellido_paterno = "";


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
                    
                    if(item.id_persona!= 0)
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
                         where (p.id_localidad == codigolocalidad && p.id_seccion == codigoseccion && p.id_cargo == codigoCargo)
                         // where p.id_localidad == codigolocalidad
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


        public PERSONA obtenerPersonasXId(int id)
        {
            try
            {
                PERSONA persona = new PERSONA();
                var context = new PresupuestoDBEntities();
                persona = (from p in context.PERSONA
                           where p.id_persona == id
                           select p).First();


                return persona;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public Boolean editarPersona(PERSONA persona)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                PERSONA obj = (from a in context.PERSONA
                               where a.id_persona == persona.id_persona
                               select a).First();
                obj.id_categoria = persona.id_categoria;
                obj.id_cargo = persona.id_cargo;
                obj.id_localidad = persona.id_localidad;
                obj.id_seccion = persona.id_seccion;
                obj.nombres_persona = persona.nombres_persona;
                DateTime now = DateTime.Now;
                persona.fecha_creacion = now;
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public Boolean editarEstadoPersona(int id, string nuevoEstado)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                PERSONA obj = (from a in context.PERSONA
                               where a.id_persona == id
                               select a).First();
                obj.estado_persona = nuevoEstado;               
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<PERSONA> listarPersonasXEstado(string estado)
        {
            try
            {
                List<PERSONA> lista = new List<PERSONA>();
                var context = new PresupuestoDBEntities();
                lista = (from p in context.PERSONA
                         where p.estado_persona == estado 
                         select p).ToList();
               


                return lista;

            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public List<PERSONA> listarPersonasXEstado(int idPeriodoPresupuesto)
        {
            try
            {
                List<PERSONA> lista = new List<PERSONA>();
                var context = new PresupuestoDBEntities();
                lista = (from p in context.PERSONA
                         where p.id_periodo_presupuesto == idPeriodoPresupuesto
                         select p).ToList();



                return lista;

            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public List<PersonalProyectadoBE> listarPersonalProyectadoBE(Int32 id_categoria, String estado, Int32 id_localidad, Int32 id_area, Int32 id_Seccion)
        {
            try
            {
                List<PersonalProyectadoBE> lista = new List<PersonalProyectadoBE>();
                PersonalProyectadoBE objpersonaBE;
                var context = new PresupuestoDBEntities();
                var prueba = (from p in context.PERSONA
                              join s in context.SECCION on p.id_seccion equals s.id_seccion
                              join a in context.AREA on s.id_area equals a.id_area
                              join l in context.LOCALIDAD on p.id_localidad equals l.id_localidad
                              join c in context.CARGO_PERSONAL on p.id_cargo equals c.id_cargo
                              join ca in context.CATEGORIA_PERSONAL on p.id_categoria equals ca.id_categoria
                              where ((p.id_persona != 0) && (id_categoria == 0 || p.id_categoria == id_categoria) &&
                                     (estado == "" || p.estado_persona == estado) && (id_localidad == 0 || p.id_localidad == id_localidad) &&
                                     (id_area == 0 || s.id_area == id_area) && (id_Seccion == 0 || p.id_seccion == id_Seccion))
                              select new
                              {
                                  p.id_persona,
                                  p.nombres_persona,
                                  p.apellido_paterno,
                                  p.apellido_materno,
                                  p.fecha_creacion,
                                  p.estado_persona,
                                  p.id_categoria,
                                  ca.nombre_categoria,
                                  p.id_cargo,
                                  c.nombre_cargo,
                                  p.id_localidad,
                                  l.nombre_localidad,
                                  a.id_area,
                                  a.nombre_area,
                                  p.id_seccion,
                                  s.nombre_seccion
                              }).ToList();

                foreach (var item in prueba)
                {
                    String nombre = item.nombres_persona + " " + item.apellido_paterno + " " + item.apellido_materno;
                    objpersonaBE = new PersonalProyectadoBE();
                    objpersonaBE.Id_persona = item.id_persona;
                    objpersonaBE.Identificador = nombre;
                    objpersonaBE.Id_categoria = item.id_categoria;
                    objpersonaBE.Id_localidad = item.id_localidad;
                    objpersonaBE.Id_area = item.id_area;
                    objpersonaBE.Id_seccion = item.id_seccion;
                    objpersonaBE.Estado = item.estado_persona;
                    objpersonaBE.Fecha_creacion = item.fecha_creacion;

                    
                    lista.Add(objpersonaBE);
                }

                return lista;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
