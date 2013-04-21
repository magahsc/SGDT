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
                              group new { p, c } by new { p.id_persona, p.nombres_persona, p.apellido_paterno, p.apellido_materno, c.nombre_cargo } into datos
                              select datos).ToList();

                foreach (var item in prueba)
                {
                    List<int> objprueba = new List<int>();
                    foreach (var item2 in item)
                    {
                        int index = objprueba.IndexOf(item2.p.id_persona);
                        if (index == -1)
                        {
                            String nombre = item2.p.nombres_persona + " " + item2.p.apellido_paterno + " " + item2.p.apellido_materno;
                            objpersonaBE = new PersonaBE();
                            objpersonaBE.Id_persona = item2.p.id_persona;
                            objpersonaBE.Nombre_persona = nombre;
                            objpersonaBE.Cargo_persona = item2.c.nombre_cargo;
                            lista.Add(objpersonaBE);

                        }
                    }
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
