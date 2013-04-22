using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GNRS.ModuloPresupuesto.BL.BC;
using GNRS.ModuloPresupuesto.DL.DALC;
using GNRS.ModuloPresupuesto.BL.BE;
using System.Data.Entity;

namespace TestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            
        }
        CapacitarProyectadoBC obj = new CapacitarProyectadoBC();

        [TestMethod]
        public void listarLocalidades()
        {
            List<LOCALIDAD> lista = obj.listarLocalidades();
            Assert.IsNotNull(lista);
        }

        [TestMethod]
        public void listarAreas()
        {
            List<AREA> lista = obj.listarAreas();
            Assert.IsNotNull(lista);
        }

        [TestMethod]
        public void listarSecciones()
        {
            List<SECCION> lista = obj.listarSecciones();
            Assert.IsNotNull(lista);
        }
        
        
        [TestMethod]
        public void filtroDeAreasXLocalidades()
        {
            List<AREA> lista = obj.filtrarAreasXLocalidad(2);
            Assert.IsNotNull(lista);
        }
        
        [TestMethod]
        public void filtroDeAreasXLocalidadesDevuelveNull()
        {
            List<AREA> lista = obj.filtrarAreasXLocalidad(100);
            Assert.IsNull(lista);
        }


        [TestMethod]
        public void filtrarSeccionesXAreaLocalidad()
        {
            List<SECCION> lista = obj.filtrarSeccionesXAreaLocalidad(1, 2);
            Assert.IsNotNull(lista);
        }

        [TestMethod]
        public void listarInstituciones()
        {
            List<INSTITUCION> lista = obj.listarInstituciones();
            Assert.IsNotNull(lista);
        }

        [TestMethod]
        public void listarCursos()
        {
            List<CURSO> lista = obj.listarCurso();
            Assert.IsNotNull(lista);
        }

        [TestMethod]
        public void ObtenerCurso()
        {
            CURSO curso = obj.obtenerCurso(4);
            Assert.IsNotNull(curso);
        }

        [TestMethod]
        public void registrarCapacitacionProyectadaxPersonaFallida()
        {
            PRESUPUESTO_CAPACITACION_POR_PERSONAL objcapacitacion = new PRESUPUESTO_CAPACITACION_POR_PERSONAL();
            Boolean result = obj.insertarcapacitacionProyectadaxPersona(objcapacitacion);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void registrarCapacitacionProyectadaFallida()
        {
            PRESUPUESTO_CAPACITACION objcapacitacion = new PRESUPUESTO_CAPACITACION();
            int result = obj.insertarcapacitacionProyectada(objcapacitacion);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void ActualizarCapacitacionProyectadaFallida()
        {
            PRESUPUESTO_CAPACITACION objcapacitacion = new PRESUPUESTO_CAPACITACION();
            Boolean result = obj.ActualizarcapacitacionProyectada(objcapacitacion);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void registrarCapacitacionProyectadaxPersonaCorrecto()
        {
            PRESUPUESTO_CAPACITACION_POR_PERSONAL objcapacitacion = new PRESUPUESTO_CAPACITACION_POR_PERSONAL();
            objcapacitacion.id_persona = 4;
            objcapacitacion.id_presupuesto_capacitacion = 11;
            objcapacitacion.monto_presupuesto_proyectado = 254.3;
            Boolean result = obj.insertarcapacitacionProyectadaxPersona(objcapacitacion);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void registrarCapacitacionProyectadaCorrecto()
        {
            PRESUPUESTO_CAPACITACION objcapacitacion = new PRESUPUESTO_CAPACITACION();
            objcapacitacion.cantidad_personas = 2;
            objcapacitacion.codigo_presupuesto = "";
            DateTime date = DateTime.Now;
            objcapacitacion.fecha_creacion = date;
            objcapacitacion.id_curso = 4;
            objcapacitacion.id_localidad = 1;
            objcapacitacion.id_seccion = 1;
            objcapacitacion.id_periodo_presupuesto = 0;
            objcapacitacion.monto_total = 450.56;
            objcapacitacion.presupuesto_aprobado = "P";

            int result = obj.insertarcapacitacionProyectada(objcapacitacion);
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void ActualizarCapacitacionProyectadaCorrecto()
        {
            PRESUPUESTO_CAPACITACION objcapacitacion = new PRESUPUESTO_CAPACITACION();
            objcapacitacion.id_presupuesto_capacitacion = 11;
            objcapacitacion.codigo_presupuesto = "01051310";
            Boolean result = obj.ActualizarcapacitacionProyectada(objcapacitacion);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void listaPersona()
        {
            List<PersonaBE> lista = obj.listarPersona(1, 2, 1);
            Assert.IsNotNull(lista);
        }


        }
    
}
