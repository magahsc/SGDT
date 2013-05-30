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
                              where (p.fecha_creacion.Month == objcapacitacion.Mes || objcapacitacion.Mes == 0) && (p.fecha_creacion.Year == objcapacitacion.Anio || objcapacitacion.Anio == 0) && (p.presupuesto_aprobado == objcapacitacion.Presupuesto_aprobado || objcapacitacion.Presupuesto_aprobado == "V")
                              select new { p.id_presupuesto_capacitacion, p.codigo_presupuesto, c.nombre_curso, p.monto_total, c.tipo_moneda, p.fecha_creacion, p.presupuesto_aprobado }).ToList();

                foreach (var item in prueba)
                {
                    if (item.tipo_moneda.Equals("S"))
                        tipo = "S/. ";
                    if (item.tipo_moneda.Equals("D"))
                        tipo = "$ ";

                    objcapacitacionBE = new CapacitacionProyectadaBE();
                    objcapacitacionBE.Smonto_total = tipo + "" + Math.Round(item.monto_total, 2);
                    objcapacitacionBE.IdEditar_presupuesto_capacitacion = item.id_presupuesto_capacitacion;
                    objcapacitacionBE.Id_presupuesto_capacitacion = item.id_presupuesto_capacitacion;
                    objcapacitacionBE.Cod_presupuesto = item.codigo_presupuesto;
                    objcapacitacionBE.Nombre_curso = item.nombre_curso;

                    String dia = Convert.ToString(item.fecha_creacion.Day);
                    String mes = Convert.ToString(item.fecha_creacion.Month);
                    String anio = Convert.ToString(item.fecha_creacion.Year);
                    anio = anio.Substring(2, 2);

                    objcapacitacionBE.Fecha_creacion = item.fecha_creacion;
                    objcapacitacionBE.Fecha_modificada = cambiarmesydia(dia) + "/" + cambiarmesydia(mes) + "/" + anio;

                    if (item.presupuesto_aprobado.Equals("A"))
                        objcapacitacionBE.Presupuesto_aprobado = "Aprobado";
                    if (item.presupuesto_aprobado.Equals("N"))
                        objcapacitacionBE.Presupuesto_aprobado = "No aprobado";
                    if (item.presupuesto_aprobado.Equals("P"))
                        objcapacitacionBE.Presupuesto_aprobado = "Pendiente";

                    if (!item.presupuesto_aprobado.Equals("E") && item.id_presupuesto_capacitacion != 0)
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

        //Nuevo
        public Boolean ActualizarCapacitacionProyectadaDatos(PRESUPUESTO_CAPACITACION objcapacitacion)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                PRESUPUESTO_CAPACITACION presupuestocapitalizacion = new PRESUPUESTO_CAPACITACION();

                presupuestocapitalizacion = (from c in context.PRESUPUESTO_CAPACITACION
                                             where c.id_presupuesto_capacitacion == objcapacitacion.id_presupuesto_capacitacion
                                             select c).First();

                presupuestocapitalizacion.id_curso = objcapacitacion.id_curso;
                presupuestocapitalizacion.id_localidad = objcapacitacion.id_localidad;
                presupuestocapitalizacion.id_seccion = objcapacitacion.id_seccion;
                presupuestocapitalizacion.monto_total = objcapacitacion.monto_total;
                presupuestocapitalizacion.cantidad_personas = objcapacitacion.cantidad_personas;
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public Boolean EliminarCapacitacionProyectadaxPersona(PRESUPUESTO_CAPACITACION_POR_PERSONAL objcapacitacionxpersona)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                PRESUPUESTO_CAPACITACION_POR_PERSONAL presupuestocapitalizacion = new PRESUPUESTO_CAPACITACION_POR_PERSONAL();

                var prueba = (from p in context.PRESUPUESTO_CAPACITACION_POR_PERSONAL
                              where p.id_presupuesto_capacitacion == objcapacitacionxpersona.id_presupuesto_capacitacion
                              select p).ToList();

                foreach (var item in prueba)
                {
                    context.PRESUPUESTO_CAPACITACION_POR_PERSONAL.DeleteObject(item);
                }

                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public String cambiarmesydia(String dato)
        {
            String sdato = dato;
            switch (dato)
            {
                case "1":
                    {
                        sdato = "01";
                        break;
                    }

                case "2":
                    {
                        sdato = "02";
                        break;
                    }

                case "3":
                    {
                        sdato = "03";
                        break;
                    }

                case "4":
                    {
                        sdato = "04";
                        break;
                    }

                case "5":
                    {
                        sdato = "05";
                        break;
                    }

                case "6":
                    {
                        sdato = "06";
                        break;
                    }

                case "7":
                    {
                        sdato = "07";
                        break;
                    }

                case "8":
                    {
                        sdato = "08";
                        break;
                    }

                case "9":
                    {
                        sdato = "09";
                        break;
                    }

            }

            return sdato;
        }
    }
}
