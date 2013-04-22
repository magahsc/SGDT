using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GNRS.ModuloPresupuesto.BL.BC;
using GNRS.ModuloPresupuesto.DL.DALC;
using System.Data.Entity;

namespace TestProject2
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        PresupuestoPersonalProyectadoBC obj = new PresupuestoPersonalProyectadoBC();


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
        public void listarCargos()
        {
            List<CARGO_PERSONAL> lista = obj.listarCargos();
            Assert.IsNotNull(lista);
        }
        
        [TestMethod]
        public void filtroDeAreasXLocalidades()
        {
            List<AREA> lista = obj.filtrarAreasXLocalidad(1);
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
        public void filtrarCargosSeccion()
        {
            List<CARGO_PERSONAL> lista = obj.filtrarCargosXSeccion(1);
            Assert.IsNotNull(lista);
        }

        [TestMethod]
        public void filtrarConceptosXTipo()
        {
            List<CONCEPTO_REMUNERACION> lista = obj.filtrarConceptosXTipo(1);
            Assert.IsNotNull(lista);
        }

        [TestMethod]
        public void registroPersonalProyectadoExitoso()
        {
            int cod=obj.registrarPersonalProyectar(1,1,1,1,"carg0 1");
            Assert.AreNotEqual(-1, cod);
        }

        [TestMethod]
        public void registroPersonalProyectadoFallido()
        {
            int cod = obj.registrarPersonalProyectar(1, 1, 1, -1, "carg0 1");
            Assert.AreEqual(-1, cod);
        }

        [TestMethod]
        public void registrarConceptoXPersonaExitoso()
        {
            Boolean result=obj.registrarConceptoXPersona(1, 1, 100);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void registrarConceptoXPersonaFallido()
        {
            Boolean result = obj.registrarConceptoXPersona(1, 5000, 100);
            Assert.AreEqual(false, result);
        }

    }
}
