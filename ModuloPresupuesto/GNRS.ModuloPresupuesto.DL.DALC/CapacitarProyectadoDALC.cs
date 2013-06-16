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
        //cambios
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

                    if ((item.presupuesto_aprobado.Equals("P") || item.presupuesto_aprobado.Equals("N") || item.presupuesto_aprobado.Equals("A")) && item.id_presupuesto_capacitacion != 0)
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


        //Nuevo
        public List<AprobarPresupuestoBE> ListarCapacitacionParaAprobar(AprobarPresupuestoBE objAprobar, String estado)
        {
            String tipo = "";
            try
            {
                List<AprobarPresupuestoBE> lista = new List<AprobarPresupuestoBE>();
                AprobarPresupuestoBE objAprobarBE;
                var context = new PresupuestoDBEntities();
                var prueba = (from c in context.CURSO
                              join p in context.PRESUPUESTO_CAPACITACION on c.id_curso equals p.id_curso
                              join l in context.LOCALIDAD on p.id_localidad equals l.id_localidad
                              join s in context.SECCION on p.id_seccion equals s.id_seccion
                              join a in context.AREA on s.id_area equals a.id_area
                              where (p.fecha_creacion.Month == objAprobar.Mes || objAprobar.Mes == 0) && (p.fecha_creacion.Year == objAprobar.Anio || objAprobar.Anio == 0) && (p.id_seccion == objAprobar.CodSeccion || objAprobar.CodSeccion == 0)
                              && (p.id_localidad == objAprobar.CodLocalidad || objAprobar.CodLocalidad == 0) && (a.id_area == objAprobar.CodArea || objAprobar.CodArea == 0)
                              select new { p.id_presupuesto_capacitacion, c.nombre_curso, p.monto_total, c.tipo_moneda, c.fecha_inicio, c.fecha_fin, p.presupuesto_aprobado, a.nombre_area, l.nombre_localidad, s.nombre_seccion }).ToList();

                foreach (var item in prueba)
                {
                    if (item.tipo_moneda.Equals("S"))
                        tipo = "S/. ";
                    if (item.tipo_moneda.Equals("D"))
                        tipo = "$ ";

                    objAprobarBE = new AprobarPresupuestoBE();
                    objAprobarBE.SMonto = tipo + "" + Math.Round(item.monto_total, 2);
                    objAprobarBE.IdCapacitacion_Proyectada = item.id_presupuesto_capacitacion;
                    objAprobarBE.NombreCurso = item.nombre_curso;
                    objAprobarBE.NombreLocalidad = item.nombre_localidad;
                    objAprobarBE.NombreArea = item.nombre_area;
                    objAprobarBE.NombreSeccion = item.nombre_seccion;

                    int mesInicio = Convert.ToInt32(item.fecha_inicio.Month);
                    int anioInicio = Convert.ToInt32(item.fecha_inicio.Year);
                    objAprobarBE.MesInicio = sabermesxnumero(mesInicio) + " " + anioInicio;

                    int mesFin = Convert.ToInt32(item.fecha_fin.Month);
                    int anioFin = Convert.ToInt32(item.fecha_fin.Year);

                    if (item.presupuesto_aprobado.Equals("A"))
                        objAprobarBE.Presupuesto_aprobado = "Aprobado";
                    if (item.presupuesto_aprobado.Equals("N"))
                        objAprobarBE.Presupuesto_aprobado = "No aprobado";
                    if (item.presupuesto_aprobado.Equals("P"))
                        objAprobarBE.Presupuesto_aprobado = "Pendiente";

                    objAprobarBE.MesFin = sabermesxnumero(mesFin) + " " + anioFin;

                    if (item.presupuesto_aprobado.Equals(estado) && item.id_presupuesto_capacitacion != 0)
                        lista.Add(objAprobarBE);
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

        public String sabermesxnumero(int mes)
        {
            String mesd = "";
            switch (mes)
            {
                case 1:
                    {
                        mesd = "Enero";
                        break;
                    }

                case 2:
                    {
                        mesd = "Febrero";
                        break;
                    }

                case 3:
                    {
                        mesd = "Marzo";
                        break;
                    }

                case 4:
                    {
                        mesd = "Abril";
                        break;
                    }

                case 5:
                    {
                        mesd = "Mayo";
                        break;
                    }

                case 6:
                    {
                        mesd = "Junio";
                        break;
                    }

                case 7:
                    {
                        mesd = "Julio";
                        break;
                    }

                case 8:
                    {
                        mesd = "Agosto";
                        break;
                    }

                case 9:
                    {
                        mesd = "Setiembre";
                        break;
                    }

                case 10:
                    {
                        mesd = "Octubre";
                        break;
                    }

                case 11:
                    {
                        mesd = "Noviembre";
                        break;
                    }

                case 12:
                    {
                        mesd = "Diciembre";
                        break;
                    }
            }
            return mesd;
        }

        public Boolean ActualizarCapacitacionParaAprobarEstado(PRESUPUESTO_CAPACITACION objcapacitacion)
        {
            try
            {
                var context = new PresupuestoDBEntities();
                PRESUPUESTO_CAPACITACION presupuestocapitalizacion = new PRESUPUESTO_CAPACITACION();

                presupuestocapitalizacion = (from c in context.PRESUPUESTO_CAPACITACION
                                             where c.id_presupuesto_capacitacion == objcapacitacion.id_presupuesto_capacitacion
                                             select c).First();

                presupuestocapitalizacion.presupuesto_aprobado = objcapacitacion.presupuesto_aprobado;
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<AprobarPresupuestoBE> ListarCapacitacionProcesadas(AprobarPresupuestoBE objAprobar)
        {
            String tipo = "";
            try
            {
                List<AprobarPresupuestoBE> lista = new List<AprobarPresupuestoBE>();
                AprobarPresupuestoBE objAprobarBE;
                var context = new PresupuestoDBEntities();
                var prueba = (from c in context.CURSO
                              join p in context.PRESUPUESTO_CAPACITACION on c.id_curso equals p.id_curso
                              join l in context.LOCALIDAD on p.id_localidad equals l.id_localidad
                              join s in context.SECCION on p.id_seccion equals s.id_seccion
                              join au in context.AUDITORIA_PRESUPUESTO on p.id_presupuesto_capacitacion equals au.id_capacitacion_proyectada
                              join a in context.AREA on s.id_area equals a.id_area
                              where (p.fecha_creacion.Month == objAprobar.Mes || objAprobar.Mes == 0) && (p.fecha_creacion.Year == objAprobar.Anio || objAprobar.Anio == 0) && (p.id_seccion == objAprobar.CodSeccion || objAprobar.CodSeccion == 0)
                              && (p.id_localidad == objAprobar.CodLocalidad || objAprobar.CodLocalidad == 0) && (a.id_area == objAprobar.CodArea || objAprobar.CodArea == 0) && (au.tipo_accion == objAprobar.Presupuesto_aprobado || objAprobar.Presupuesto_aprobado == "T")
                              select new { p.id_presupuesto_capacitacion, c.nombre_curso, p.monto_total, c.tipo_moneda, c.fecha_inicio, c.fecha_fin, au.tipo_accion, a.nombre_area, l.nombre_localidad, s.nombre_seccion }).ToList();

                foreach (var item in prueba)
                {
                    if (item.tipo_moneda.Equals("S"))
                        tipo = "S/. ";
                    if (item.tipo_moneda.Equals("D"))
                        tipo = "$ ";

                    objAprobarBE = new AprobarPresupuestoBE();
                    objAprobarBE.SMonto = tipo + "" + Math.Round(item.monto_total, 2);
                    objAprobarBE.IdCapacitacion_Proyectada = item.id_presupuesto_capacitacion;
                    objAprobarBE.NombreCurso = item.nombre_curso;
                    objAprobarBE.NombreLocalidad = item.nombre_localidad;
                    objAprobarBE.NombreArea = item.nombre_area;
                    objAprobarBE.NombreSeccion = item.nombre_seccion;

                    int mesInicio = Convert.ToInt32(item.fecha_inicio.Month);
                    int anioInicio = Convert.ToInt32(item.fecha_inicio.Year);
                    objAprobarBE.MesInicio = sabermesxnumero(mesInicio) + " " + anioInicio;

                    int mesFin = Convert.ToInt32(item.fecha_fin.Month);
                    int anioFin = Convert.ToInt32(item.fecha_fin.Year);

                    if (item.tipo_accion.Equals("A"))
                        objAprobarBE.Presupuesto_aprobado = "Actualizado";
                    if (item.tipo_accion.Equals("AP"))
                        objAprobarBE.Presupuesto_aprobado = "Aprobación de Presupuesto";
                    if (item.tipo_accion.Equals("E"))
                        objAprobarBE.Presupuesto_aprobado = "Eliminado";
                    if (item.tipo_accion.Equals("ES"))
                        objAprobarBE.Presupuesto_aprobado = "Envío de solicitud";
                    if (item.tipo_accion.Equals("PA"))
                        objAprobarBE.Presupuesto_aprobado = "Preaprobado";
                    if (item.tipo_accion.Equals("R"))
                        objAprobarBE.Presupuesto_aprobado = "Rechazado";

                    objAprobarBE.MesFin = sabermesxnumero(mesFin) + " " + anioFin;

                    if (!item.tipo_accion.Equals("N") && item.id_presupuesto_capacitacion != 0)
                        lista.Add(objAprobarBE);
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
    }
}
