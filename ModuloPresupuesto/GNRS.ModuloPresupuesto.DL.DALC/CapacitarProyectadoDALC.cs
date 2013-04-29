using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using GNRS.ModuloPresupuesto.BL.BE;

namespace GNRS.ModuloPresupuesto.DL.DALC
{
    public class CapacitarProyectadoDALC
    {
        public int insertarCapacitacionProyectada(PRESUPUESTO_CAPACITACION objcapacitacion)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                context.PRESUPUESTO_CAPACITACION.AddObject(objcapacitacion);
                context.SaveChanges();
                int i = objcapacitacion.id_presupuesto_capacitacion;
                return i;

            }
            catch (Exception ex)
            {
                throw;

            }
        }

        public Boolean insertarCapacitacionProyectadaxPersona(PRESUPUESTO_CAPACITACION_POR_PERSONAL objcapacitacionxpersona)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                context.PRESUPUESTO_CAPACITACION_POR_PERSONAL.AddObject(objcapacitacionxpersona);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public Boolean ActualizarCapacitacionProyectada(PRESUPUESTO_CAPACITACION objcapacitacion)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                PRESUPUESTO_CAPACITACION presupuestocapitalizacion = new PRESUPUESTO_CAPACITACION();

                presupuestocapitalizacion = (from c in context.PRESUPUESTO_CAPACITACION
                         where c.id_presupuesto_capacitacion == objcapacitacion.id_presupuesto_capacitacion
                         select c).First();

                presupuestocapitalizacion.codigo_presupuesto = objcapacitacion.codigo_presupuesto;
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        
        }

        public List<CapacitacionProyectadaBE> ListarCapacitacionProyectadaxMesxAnioxEstado(CapacitacionProyectadaBE objcapacitacion)
        {
            String tipo = "";
            try
            {
                List<CapacitacionProyectadaBE> lista = new List<CapacitacionProyectadaBE>();
                CapacitacionProyectadaBE objcapacitacionBE;
                var context = new PresupuestoDBEntities();
                var prueba = (from c in context.CURSO
                              join p in context.PRESUPUESTO_CAPACITACION on c.id_curso equals p.id_curso
                              where p.fecha_creacion.Month == objcapacitacion.Mes && p.fecha_creacion.Year == objcapacitacion.Anio && p.presupuesto_aprobado == objcapacitacion.Presupuesto_aprobado
                              select new { p.id_presupuesto_capacitacion, p.codigo_presupuesto, c.nombre_curso, p.monto_total, c.tipo_moneda, p.fecha_creacion, p.presupuesto_aprobado}).ToList();

                foreach (var item in prueba)
                {
                    if(item.tipo_moneda.Equals("S"))
                        tipo = "S/. ";
                    if(item.tipo_moneda.Equals("S"))
                        tipo = "$ ";

                    objcapacitacionBE = new CapacitacionProyectadaBE();
                    objcapacitacionBE.Smonto_total = tipo + "" + item.monto_total;
                    objcapacitacionBE.Id_presupuesto_capacitacion = item.id_presupuesto_capacitacion;
                    objcapacitacionBE.Cod_presupuesto = item.codigo_presupuesto;
                    objcapacitacionBE.Nombre_curso = item.nombre_curso;

                    String dia = Convert.ToString(item.fecha_creacion.Day);
                    String mes = Convert.ToString(item.fecha_creacion.Month);
                    String anio = Convert.ToString(item.fecha_creacion.Year);
                    anio = anio.Substring(2, 2);

                    objcapacitacionBE.Fecha_creacion = item.fecha_creacion;
                    objcapacitacionBE.Fecha_modificada = anio;

                    if (item.presupuesto_aprobado.Equals("A"))
                        objcapacitacionBE.Presupuesto_aprobado = "Aprobado";
                    if (item.presupuesto_aprobado.Equals("N"))
                        objcapacitacionBE.Presupuesto_aprobado = "No aprobado";
                    if (item.presupuesto_aprobado.Equals("P"))
                        objcapacitacionBE.Presupuesto_aprobado = "Pendiente";

                    if(!item.presupuesto_aprobado.Equals("E"))
                       lista.Add(objcapacitacionBE);
                }

                if (lista.Count() > 0)
                    return lista;
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<CapacitacionProyectadaBE> ListarCapacitacionProyectadaxMes(CapacitacionProyectadaBE objcapacitacion)
        {
            String tipo = "";
            try
            {
                List<CapacitacionProyectadaBE> lista = new List<CapacitacionProyectadaBE>();
                CapacitacionProyectadaBE objcapacitacionBE;
                var context = new PresupuestoDBEntities();
                var prueba = (from c in context.CURSO
                              join p in context.PRESUPUESTO_CAPACITACION on c.id_curso equals p.id_curso
                              where p.fecha_creacion.Month == objcapacitacion.Mes
                              select new { p.id_presupuesto_capacitacion, p.codigo_presupuesto, c.nombre_curso, p.monto_total, c.tipo_moneda, p.fecha_creacion, p.presupuesto_aprobado }).ToList();

                foreach (var item in prueba)
                {
                    if (item.tipo_moneda.Equals("S"))
                        tipo = "S/. ";
                    if (item.tipo_moneda.Equals("S"))
                        tipo = "$ ";

                    objcapacitacionBE = new CapacitacionProyectadaBE();
                    objcapacitacionBE.Smonto_total = tipo + "" + item.monto_total;
                    objcapacitacionBE.Id_presupuesto_capacitacion = item.id_presupuesto_capacitacion;
                    objcapacitacionBE.Cod_presupuesto = item.codigo_presupuesto;
                    objcapacitacionBE.Nombre_curso = item.nombre_curso;

                    String dia = Convert.ToString(item.fecha_creacion.Day);
                    String mes = Convert.ToString(item.fecha_creacion.Month);
                    String anio = Convert.ToString(item.fecha_creacion.Year);
                    anio = anio.Substring(2, 2);

                    objcapacitacionBE.Fecha_creacion = item.fecha_creacion;
                    objcapacitacionBE.Fecha_modificada = anio;

                    if (item.presupuesto_aprobado.Equals("A"))
                        objcapacitacionBE.Presupuesto_aprobado = "Aprobado";
                    if (item.presupuesto_aprobado.Equals("N"))
                        objcapacitacionBE.Presupuesto_aprobado = "No aprobado";
                    if (item.presupuesto_aprobado.Equals("P"))
                        objcapacitacionBE.Presupuesto_aprobado = "Pendiente";

                    if (!item.presupuesto_aprobado.Equals("E"))
                        lista.Add(objcapacitacionBE);
                }

                if (lista.Count() > 0)
                    return lista;
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<CapacitacionProyectadaBE> ListarCapacitacionProyectadaxAnio(CapacitacionProyectadaBE objcapacitacion)
        {
            String tipo = "";
            try
            {
                List<CapacitacionProyectadaBE> lista = new List<CapacitacionProyectadaBE>();
                CapacitacionProyectadaBE objcapacitacionBE;
                var context = new PresupuestoDBEntities();
                var prueba = (from c in context.CURSO
                              join p in context.PRESUPUESTO_CAPACITACION on c.id_curso equals p.id_curso
                              where p.fecha_creacion.Year == objcapacitacion.Anio 
                              select new { p.id_presupuesto_capacitacion, p.codigo_presupuesto, c.nombre_curso, p.monto_total, c.tipo_moneda, p.fecha_creacion, p.presupuesto_aprobado }).ToList();

                foreach (var item in prueba)
                {
                    if (item.tipo_moneda.Equals("S"))
                        tipo = "S/. ";
                    if (item.tipo_moneda.Equals("S"))
                        tipo = "$ ";

                    objcapacitacionBE = new CapacitacionProyectadaBE();
                    objcapacitacionBE.Smonto_total = tipo + "" + item.monto_total;
                    objcapacitacionBE.Id_presupuesto_capacitacion = item.id_presupuesto_capacitacion;
                    objcapacitacionBE.Cod_presupuesto = item.codigo_presupuesto;
                    objcapacitacionBE.Nombre_curso = item.nombre_curso;

                    String dia = Convert.ToString(item.fecha_creacion.Day);
                    String mes = Convert.ToString(item.fecha_creacion.Month);
                    String anio = Convert.ToString(item.fecha_creacion.Year);
                    anio = anio.Substring(2, 2);

                    objcapacitacionBE.Fecha_creacion = item.fecha_creacion;
                    objcapacitacionBE.Fecha_modificada = anio;

                    if (item.presupuesto_aprobado.Equals("A"))
                        objcapacitacionBE.Presupuesto_aprobado = "Aprobado";
                    if (item.presupuesto_aprobado.Equals("N"))
                        objcapacitacionBE.Presupuesto_aprobado = "No aprobado";
                    if (item.presupuesto_aprobado.Equals("P"))
                        objcapacitacionBE.Presupuesto_aprobado = "Pendiente";

                    if (!item.presupuesto_aprobado.Equals("E"))
                        lista.Add(objcapacitacionBE);
                }

                if (lista.Count() > 0)
                    return lista;
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<CapacitacionProyectadaBE> ListarCapacitacionProyectadaxEstado(CapacitacionProyectadaBE objcapacitacion)
        {
            String tipo = "";
            try
            {
                List<CapacitacionProyectadaBE> lista = new List<CapacitacionProyectadaBE>();
                CapacitacionProyectadaBE objcapacitacionBE;
                var context = new PresupuestoDBEntities();
                var prueba = (from c in context.CURSO
                              join p in context.PRESUPUESTO_CAPACITACION on c.id_curso equals p.id_curso
                              where  p.presupuesto_aprobado == objcapacitacion.Presupuesto_aprobado
                              select new { p.id_presupuesto_capacitacion, p.codigo_presupuesto, c.nombre_curso, p.monto_total, c.tipo_moneda, p.fecha_creacion, p.presupuesto_aprobado }).ToList();

                foreach (var item in prueba)
                {
                    if (item.tipo_moneda.Equals("S"))
                        tipo = "S/. ";
                    if (item.tipo_moneda.Equals("S"))
                        tipo = "$ ";

                    objcapacitacionBE = new CapacitacionProyectadaBE();
                    objcapacitacionBE.Smonto_total = tipo + "" + item.monto_total;
                    objcapacitacionBE.Id_presupuesto_capacitacion = item.id_presupuesto_capacitacion;
                    objcapacitacionBE.Cod_presupuesto = item.codigo_presupuesto;
                    objcapacitacionBE.Nombre_curso = item.nombre_curso;

                    String dia = Convert.ToString(item.fecha_creacion.Day);
                    String mes = Convert.ToString(item.fecha_creacion.Month);
                    String anio = Convert.ToString(item.fecha_creacion.Year);
                    anio = anio.Substring(2, 2);

                    objcapacitacionBE.Fecha_creacion = item.fecha_creacion;
                    objcapacitacionBE.Fecha_modificada = anio;

                    if (item.presupuesto_aprobado.Equals("A"))
                        objcapacitacionBE.Presupuesto_aprobado = "Aprobado";
                    if (item.presupuesto_aprobado.Equals("N"))
                        objcapacitacionBE.Presupuesto_aprobado = "No aprobado";
                    if (item.presupuesto_aprobado.Equals("P"))
                        objcapacitacionBE.Presupuesto_aprobado = "Pendiente";

                    if (!item.presupuesto_aprobado.Equals("E"))
                        lista.Add(objcapacitacionBE);
                }

                if (lista.Count() > 0)
                    return lista;
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<CapacitacionProyectadaBE> ListarCapacitacionProyectadaxMesxAnio(CapacitacionProyectadaBE objcapacitacion)
        {
            String tipo = "";
            try
            {
                List<CapacitacionProyectadaBE> lista = new List<CapacitacionProyectadaBE>();
                CapacitacionProyectadaBE objcapacitacionBE;
                var context = new PresupuestoDBEntities();
                var prueba = (from c in context.CURSO
                              join p in context.PRESUPUESTO_CAPACITACION on c.id_curso equals p.id_curso
                              where p.fecha_creacion.Month == objcapacitacion.Mes && p.fecha_creacion.Year == objcapacitacion.Anio 
                              select new { p.id_presupuesto_capacitacion, p.codigo_presupuesto, c.nombre_curso, p.monto_total, c.tipo_moneda, p.fecha_creacion, p.presupuesto_aprobado }).ToList();

                foreach (var item in prueba)
                {
                    if (item.tipo_moneda.Equals("S"))
                        tipo = "S/. ";
                    if (item.tipo_moneda.Equals("S"))
                        tipo = "$ ";

                    objcapacitacionBE = new CapacitacionProyectadaBE();
                    objcapacitacionBE.Smonto_total = tipo + "" + item.monto_total;
                    objcapacitacionBE.Id_presupuesto_capacitacion = item.id_presupuesto_capacitacion;
                    objcapacitacionBE.Cod_presupuesto = item.codigo_presupuesto;
                    objcapacitacionBE.Nombre_curso = item.nombre_curso;

                    String dia = Convert.ToString(item.fecha_creacion.Day);
                    String mes = Convert.ToString(item.fecha_creacion.Month);
                    String anio = Convert.ToString(item.fecha_creacion.Year);
                    anio = anio.Substring(2, 2);

                    objcapacitacionBE.Fecha_creacion = item.fecha_creacion;
                    objcapacitacionBE.Fecha_modificada = anio;

                    if (item.presupuesto_aprobado.Equals("A"))
                        objcapacitacionBE.Presupuesto_aprobado = "Aprobado";
                    if (item.presupuesto_aprobado.Equals("N"))
                        objcapacitacionBE.Presupuesto_aprobado = "No aprobado";
                    if (item.presupuesto_aprobado.Equals("P"))
                        objcapacitacionBE.Presupuesto_aprobado = "Pendiente";

                    if (!item.presupuesto_aprobado.Equals("E"))
                        lista.Add(objcapacitacionBE);
                }

                if (lista.Count() > 0)
                    return lista;
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<CapacitacionProyectadaBE> ListarCapacitacionProyectadaxAnioxEstado(CapacitacionProyectadaBE objcapacitacion)
        {
            String tipo = "";
            try
            {
                List<CapacitacionProyectadaBE> lista = new List<CapacitacionProyectadaBE>();
                CapacitacionProyectadaBE objcapacitacionBE;
                var context = new PresupuestoDBEntities();
                var prueba = (from c in context.CURSO
                              join p in context.PRESUPUESTO_CAPACITACION on c.id_curso equals p.id_curso
                              where p.fecha_creacion.Year == objcapacitacion.Anio && p.presupuesto_aprobado == objcapacitacion.Presupuesto_aprobado
                              select new { p.id_presupuesto_capacitacion, p.codigo_presupuesto, c.nombre_curso, p.monto_total, c.tipo_moneda, p.fecha_creacion, p.presupuesto_aprobado }).ToList();

                foreach (var item in prueba)
                {
                    if (item.tipo_moneda.Equals("S"))
                        tipo = "S/. ";
                    if (item.tipo_moneda.Equals("S"))
                        tipo = "$ ";

                    objcapacitacionBE = new CapacitacionProyectadaBE();
                    objcapacitacionBE.Smonto_total = tipo + "" + item.monto_total;
                    objcapacitacionBE.Id_presupuesto_capacitacion = item.id_presupuesto_capacitacion;
                    objcapacitacionBE.Cod_presupuesto = item.codigo_presupuesto;
                    objcapacitacionBE.Nombre_curso = item.nombre_curso;

                    String dia = Convert.ToString(item.fecha_creacion.Day);
                    String mes = Convert.ToString(item.fecha_creacion.Month);
                    String anio = Convert.ToString(item.fecha_creacion.Year);
                    anio = anio.Substring(2, 2);

                    objcapacitacionBE.Fecha_creacion = item.fecha_creacion;
                    objcapacitacionBE.Fecha_modificada = anio;

                    if (item.presupuesto_aprobado.Equals("A"))
                        objcapacitacionBE.Presupuesto_aprobado = "Aprobado";
                    if (item.presupuesto_aprobado.Equals("N"))
                        objcapacitacionBE.Presupuesto_aprobado = "No aprobado";
                    if (item.presupuesto_aprobado.Equals("P"))
                        objcapacitacionBE.Presupuesto_aprobado = "Pendiente";

                    if (!item.presupuesto_aprobado.Equals("E"))
                        lista.Add(objcapacitacionBE);
                }

                if (lista.Count() > 0)
                    return lista;
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<CapacitacionProyectadaBE> ListarCapacitacionProyectadaxMesxEstado(CapacitacionProyectadaBE objcapacitacion)
        {
            String tipo = "";
            try
            {
                List<CapacitacionProyectadaBE> lista = new List<CapacitacionProyectadaBE>();
                CapacitacionProyectadaBE objcapacitacionBE;
                var context = new PresupuestoDBEntities();
                var prueba = (from c in context.CURSO
                              join p in context.PRESUPUESTO_CAPACITACION on c.id_curso equals p.id_curso
                              where p.fecha_creacion.Month == objcapacitacion.Mes  && p.presupuesto_aprobado == objcapacitacion.Presupuesto_aprobado
                              select new { p.id_presupuesto_capacitacion, p.codigo_presupuesto, c.nombre_curso, p.monto_total, c.tipo_moneda, p.fecha_creacion, p.presupuesto_aprobado }).ToList();

                foreach (var item in prueba)
                {
                    if (item.tipo_moneda.Equals("S"))
                        tipo = "S/. ";
                    if (item.tipo_moneda.Equals("S"))
                        tipo = "$ ";

                    objcapacitacionBE = new CapacitacionProyectadaBE();
                    objcapacitacionBE.Smonto_total = tipo + "" + item.monto_total;
                    objcapacitacionBE.Id_presupuesto_capacitacion = item.id_presupuesto_capacitacion;
                    objcapacitacionBE.Cod_presupuesto = item.codigo_presupuesto;
                    objcapacitacionBE.Nombre_curso = item.nombre_curso;

                    String dia = Convert.ToString(item.fecha_creacion.Day);
                    String mes = Convert.ToString(item.fecha_creacion.Month);
                    String anio = Convert.ToString(item.fecha_creacion.Year);
                    anio = anio.Substring(2, 2);

                    objcapacitacionBE.Fecha_creacion = item.fecha_creacion;
                    objcapacitacionBE.Fecha_modificada = anio;

                    if (item.presupuesto_aprobado.Equals("A"))
                        objcapacitacionBE.Presupuesto_aprobado = "Aprobado";
                    if (item.presupuesto_aprobado.Equals("N"))
                        objcapacitacionBE.Presupuesto_aprobado = "No aprobado";
                    if (item.presupuesto_aprobado.Equals("P"))
                        objcapacitacionBE.Presupuesto_aprobado = "Pendiente";

                    if (!item.presupuesto_aprobado.Equals("E"))
                        lista.Add(objcapacitacionBE);
                }

                if (lista.Count() > 0)
                    return lista;
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<CapacitacionProyectadaBE> ListarCapacitacionProyectadaxTodo()
        {
            String tipo = "";
            try
            {
                List<CapacitacionProyectadaBE> lista = new List<CapacitacionProyectadaBE>();
                CapacitacionProyectadaBE objcapacitacionBE;
                var context = new PresupuestoDBEntities();
                var prueba = (from c in context.CURSO
                              join p in context.PRESUPUESTO_CAPACITACION on c.id_curso equals p.id_curso
                              select new { p.id_presupuesto_capacitacion, p.codigo_presupuesto, c.nombre_curso, p.monto_total, c.tipo_moneda, p.fecha_creacion, p.presupuesto_aprobado }).ToList();

                foreach (var item in prueba)
                {
                    if (item.tipo_moneda.Equals("S"))
                        tipo = "S/. ";
                    if (item.tipo_moneda.Equals("S"))
                        tipo = "$ ";

                    objcapacitacionBE = new CapacitacionProyectadaBE();
                    objcapacitacionBE.Smonto_total = tipo + "" + item.monto_total;
                    objcapacitacionBE.Id_presupuesto_capacitacion = item.id_presupuesto_capacitacion;
                    objcapacitacionBE.Cod_presupuesto = item.codigo_presupuesto;
                    objcapacitacionBE.Nombre_curso = item.nombre_curso;

                    String dia = Convert.ToString(item.fecha_creacion.Day);
                    String mes = Convert.ToString(item.fecha_creacion.Month);
                    String anio = Convert.ToString(item.fecha_creacion.Year);
                    anio = anio.Substring(2, 2);

                    objcapacitacionBE.Fecha_creacion = item.fecha_creacion;
                    objcapacitacionBE.Fecha_modificada = anio;

                    if (item.presupuesto_aprobado.Equals("A"))
                        objcapacitacionBE.Presupuesto_aprobado = "Aprobado";
                    if (item.presupuesto_aprobado.Equals("N"))
                        objcapacitacionBE.Presupuesto_aprobado = "No aprobado";
                    if (item.presupuesto_aprobado.Equals("P"))
                        objcapacitacionBE.Presupuesto_aprobado = "Pendiente";

                    if (!item.presupuesto_aprobado.Equals("E"))
                        lista.Add(objcapacitacionBE);
                }

                if (lista.Count() > 0)
                    return lista;
                else
                    return null;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //nuevo
        public Boolean ActualizarEstadoCapacitacionProyectada(int id_presupuesto_capacitacion)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                PRESUPUESTO_CAPACITACION presupuestocapitalizacion = new PRESUPUESTO_CAPACITACION();

                presupuestocapitalizacion = (from c in context.PRESUPUESTO_CAPACITACION
                                             where c.id_presupuesto_capacitacion == id_presupuesto_capacitacion
                                             select c).First();

                presupuestocapitalizacion.presupuesto_aprobado = "E";
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public PRESUPUESTO_CAPACITACION obtenerPresupuestoCapacitacion(int id_presupuesto_capacitacion)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                PRESUPUESTO_CAPACITACION presupuestocapitalizacion = new PRESUPUESTO_CAPACITACION();

                presupuestocapitalizacion = (from c in context.PRESUPUESTO_CAPACITACION
                                             where c.id_presupuesto_capacitacion == id_presupuesto_capacitacion
                                             select c).First();

                return presupuestocapitalizacion;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
