﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using GNRS.ModuloPresupuesto.DL.DALC;
using GNRS.ModuloPresupuesto.BL.BE;

using System.Web.Services;

namespace GNRS.ModuloPresupuesto.BL.BC
{
    public class PresupuestoPersonalProyectadoBC
    {
        LocalidadDALC localidadDALC = new LocalidadDALC();
        AreaDALC areaDALC = new AreaDALC();
        SeccionDALC seccionDALC = new SeccionDALC();
        CargoDALC cargoDALC = new CargoDALC();
        PersonaDALC personaDALC=new PersonaDALC();
        ConceptoRemuneracionDALC conceptoRemuneracionDALC=new ConceptoRemuneracionDALC();
        ConceptoPersonaDALC objConceptoPersonaDALC=new ConceptoPersonaDALC();
        AuditoriaPresupuestoDALC objAuditoriaPresupuestoDALC = new AuditoriaPresupuestoDALC();


        public List<LOCALIDAD> listarLocalidades()
        {
            return localidadDALC.listarLocalidades();
        }

        public List<AREA> listarAreas()
        {
            return areaDALC.listarAreas();
        }

        public List<SECCION> listarSecciones()
        {
            return seccionDALC.listarSeccion();
        }
        
        public List<CARGO_PERSONAL> listarCargos()
        {
            return cargoDALC.listarCargos();
        }

        List<int> listaCodigosSeccionesXLocalidad;
        List<int> listaCodigosAreasXLocalidad;
        List<AREA> listaAreas;
        List<SECCION> listaSecciones;
        List<CARGO_PERSONAL> listaCargos;
        List<CONCEPTO_REMUNERACION> ConceptosList;

        public List<AREA> filtrarAreasXLocalidad(int codigoLocalidad)
        {
            listaCodigosSeccionesXLocalidad=seccionDALC.obtenerCodigoSeccionesLocalidad(codigoLocalidad);
            
            listaCodigosAreasXLocalidad = new List<int>();

            foreach (int item in listaCodigosSeccionesXLocalidad)
            {
                List<int> temp=areaDALC.obtenerCodigosAreasXSeccion(item);
                foreach (int codArea in temp)
                {
                    int index = listaCodigosAreasXLocalidad.IndexOf(codArea);
                    if (index == -1)
                        listaCodigosAreasXLocalidad.Add(codArea);
                } 
            }
                        
            listaAreas = new List<AREA>();
            foreach (int itemArea in listaCodigosAreasXLocalidad)
            {
                AREA temp = areaDALC.obtenerAreaXCodigo(itemArea);
                listaAreas.Add(temp);
            }

            return listaAreas;
        
        }


        public List<SECCION> filtrarSeccionesXAreaLocalidad(int codigoArea, int codigoLocalidad)
        {
            listaCodigosSeccionesXLocalidad = seccionDALC.obtenerCodigoSeccionesLocalidad(codigoLocalidad);

            listaSecciones = new List<SECCION>();
            foreach (int item in listaCodigosSeccionesXLocalidad)
            {
                SECCION temp = seccionDALC.obtenerSeccionXCodigo(item);
                if (temp != null)
                {
                    if (temp.id_area == codigoArea)
                        listaSecciones.Add(temp);
                }
            }

            return listaSecciones;
        }


        public List<CARGO_PERSONAL> filtrarCargosXSeccion(int codigoSeccion)
        {

            listaCargos = new List<CARGO_PERSONAL>();
            
            listaCargos= cargoDALC.listarCargosXSeccion(codigoSeccion);


            return listaCargos;
        }

        public List<CONCEPTO_REMUNERACION> filtrarConceptosXTipo(int tipo)
        {
            conceptoRemuneracionDALC = new ConceptoRemuneracionDALC();

            ConceptosList = new List<CONCEPTO_REMUNERACION>();
            ConceptosList = conceptoRemuneracionDALC.listaConceptoRemuneracionXTipo(tipo);

            return ConceptosList;
        }

        public int registrarPersonalProyectar(int codigoLocalidad, int codigoArea, int codigoSeccion, int codigoCargo, string nombre, int codigoTipoPersonal, int codPeridodPresupuesto)
        {
            PERSONA persona = new PERSONA();
            persona.id_localidad = codigoLocalidad;
            persona.id_seccion = codigoSeccion;
            persona.id_cargo = codigoCargo;
            persona.nombres_persona = nombre;
            persona.id_categoria = codigoTipoPersonal;
            persona.id_periodo_presupuesto = codPeridodPresupuesto;
            personaDALC = new PersonaDALC();
           
            Boolean registro=personaDALC.insertarPersonalProyectado(persona);
            int cod = persona.id_persona;

            if (registro)
            {
                return cod;
            }
            else
            {
                return -1;
            }


        }

        public Boolean registrarConceptoXPersona(int codPersona,int codConcepto,float monto,float costoEmpresa)
        {
            CONCEPTO_POR_PERSONA objConceptoPersona=new CONCEPTO_POR_PERSONA();
            objConceptoPersona.id_concepto = codConcepto;
            objConceptoPersona.id_persona = codPersona;
            objConceptoPersona.monto = monto;
            objConceptoPersona.monto_costo_empresa = costoEmpresa * monto;


            ConceptoRemuneracionDALC conceptoDALC= new ConceptoRemuneracionDALC();

            return conceptoDALC.insertarConceptoPersona(objConceptoPersona);

          

        }



        public int obtenerCodDePersonalProyectado(int codigoLocalidad, int codigoArea, int codigoSeccion, int codigoCargo, string cargo)
        {
            try
            {

                personaDALC = new PersonaDALC();
                int codigo = -1;
                List<PERSONA> lista = new List<PERSONA>();

                lista = personaDALC.obtenerPersonasXLocalidadSeccionCargo(codigoLocalidad, codigoArea, codigoSeccion, codigoCargo);

                lista.OrderBy(p => p.nombres_persona).ToList();

                if (lista.Count() > 0)
                {
                    string cargoCompleto = lista[lista.Count() - 1].nombres_persona;
                    if (cargoCompleto.Contains(cargo))
                    {
                        string temp = "";
                        temp = cargo + " Proy-";
                        int index = temp.Length;
                        string numero = cargoCompleto.Substring(index);
                        codigo = Convert.ToInt32(numero);

                    }
                    return codigo;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw;
            }

        }



        public Boolean actualizarPersonalProyectar(int codigoLocalidad, int codigoSeccion, int codigoCargo, string nombre, int codigoTipoPersonal,int id_persona)
        {
            PERSONA persona = new PERSONA();
            persona.id_localidad = codigoLocalidad;
            persona.id_seccion = codigoSeccion;
            persona.id_cargo = codigoCargo;
            persona.nombres_persona = nombre;
            persona.id_categoria = codigoTipoPersonal;
            persona.id_persona = id_persona;

         
            Boolean actualizoPersona= personaDALC.editarPersona(persona);
           //costoempres

            //eliminar
            if (actualizoPersona == true)
            {
                objConceptoPersonaDALC.eliminarConceptosXIDPersona(persona.id_persona);

                AUDITORIA_PRESUPUESTO objAuditoria=new AUDITORIA_PRESUPUESTO();
                DateTime now = DateTime.Now; 
                objAuditoria.fecha_accion=now;
                objAuditoria.id_actividad_proyectada=0;
                objAuditoria.id_capacitacion_proyectada=0;
                objAuditoria.id_personal_proyectado=id_persona;
                objAuditoria.tipo_accion="A";
                objAuditoria.tipo_presupuesto="P";
                objAuditoriaPresupuestoDALC.insertarAuditoriaProyectada(objAuditoria);

                return true;
            }
            return false;
            
        }



        public List<PersonalProyectadoBE> listarPersonalProyectadoBEXEstado(string estado)
        {
            try
            {
                List<PERSONA> listaPersona = personaDALC.listarPersonasXEstado(estado);
                List<PersonalProyectadoBE> listaPersonalProyectadoTemp = new List<PersonalProyectadoBE>();
                PersonalProyectadoBE objPersonalProyectadoTemp;

                List<SECCION> listaSeccion = new List<SECCION>();
                listaSeccion = seccionDALC.listarSeccion();
                SECCION objSeccion = new SECCION();
                foreach (PERSONA it in listaPersona)
                {
                    objPersonalProyectadoTemp = new PersonalProyectadoBE();
                    objPersonalProyectadoTemp.Fecha_creacion = it.fecha_creacion;

                    objSeccion = listaSeccion.Find(x => x.id_seccion == it.id_seccion);
                    objPersonalProyectadoTemp.Id_area = objSeccion.id_area;

                    objPersonalProyectadoTemp.Id_categoria = it.id_categoria;
                    objPersonalProyectadoTemp.Id_localidad = it.id_localidad;
                    objPersonalProyectadoTemp.Id_persona = it.id_persona;
                    objPersonalProyectadoTemp.Id_seccion = it.id_seccion;
                    objPersonalProyectadoTemp.Identificador = it.nombres_persona;

                    float remuneracion = calcularRemuneracion(it.id_persona);
                    objPersonalProyectadoTemp.Remuneracion = remuneracion;
                    listaPersonalProyectadoTemp.Add(objPersonalProyectadoTemp);

                }

                return listaPersonalProyectadoTemp;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public float calcularRemuneracion(int id_persona)
        {
            try
            {
                List<CONCEPTO_POR_PERSONA> listaConceptoPersona = objConceptoPersonaDALC.listarConceptosXPersona(id_persona);
                float remuneracion=0;

                foreach (CONCEPTO_POR_PERSONA it in listaConceptoPersona)
                {
                    remuneracion += (float)it.monto;
                    remuneracion += (float)it.monto_costo_empresa;
                }

                return remuneracion;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
