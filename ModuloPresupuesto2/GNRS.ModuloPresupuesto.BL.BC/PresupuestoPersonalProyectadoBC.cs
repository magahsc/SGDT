using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using GNRS.ModuloPresupuesto.DL.DALC;
using System.Web.Services;

namespace GNRS.ModuloPresupuesto.BL.BC
{
    public class PresupuestoPersonalProyectadoBC
    {
        LocalidadDALC localidadDALC = new LocalidadDALC();
        AreaDALC areaDALC = new AreaDALC();
        SeccionDALC seccionDALC = new SeccionDALC();
        CargoDALC cargoDALC = new CargoDALC();
        PersonaDALC personaDALC;
        ConceptoRemuneracionDALC conceptoRemuneracionDALC;



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

        public int registrarPersonalProyectar(int codigoLocalidad, int codigoArea, int codigoSeccion, int codigoCargo, string nombre)
        {
            PERSONA persona = new PERSONA();
            persona.id_localidad = codigoLocalidad;
            persona.id_seccion = codigoSeccion;
            persona.id_cargo = codigoCargo;
            persona.nombres_persona = nombre;

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

        public Boolean registrarConceptoXPersona(int codPersona,int codConcepto,float monto)
        {
            CONCEPTO_POR_PERSONA objConceptoPersona=new CONCEPTO_POR_PERSONA();
            objConceptoPersona.id_concepto = codConcepto;
            objConceptoPersona.id_persona = codPersona;
            objConceptoPersona.monto = monto;



            ConceptoRemuneracionDALC conceptoDALC= new ConceptoRemuneracionDALC();

            return conceptoDALC.insertarConceptoPersona(objConceptoPersona);

          

        }

       
    }
}
