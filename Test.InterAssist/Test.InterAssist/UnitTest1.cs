using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Data;
using Entities.InterAsisst;
using DAL.InterAssist;
using Utils.InterAssist;
using System.Xml;
using Cognitas.Framework.Repository.Interfaces;




namespace Test.InterAssist
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

        /*
        [TestMethod]
        public void TestTicket()
        {
            Entities.InterAsisst.Ticket t = new Entities.InterAsisst.Ticket();

            t.IdAfiliado = 1;
            t.IdEstado = 1;
            t.Telefono = "44322577";
            t.IDOperador = 25;

            // Datos Origen.
            t.IdPaisOrigen = 1;
            t.IdProvinciaOrigen = 1;
            t.IdCiudadOrigen = 5;
            t.IdLocalidadOrigen = 132;
            t.CalleOrigen = "Puan y Directorio";

            // Datos Destino.
            t.IdPaisDestino = 1;
            t.IdProvinciaDestino = 1;
            t.IdCiudadDestino = 5;
            t.IdLocalidadDestino = 132;
            t.CalleDestino = "Alverdi y Viel";

            t.IdPrestador = 112;
            t.IdProblema = 1;

            // Detalles
            t.Observacion = new Observacion(25);
            t.Observacion.Descripcion = "Automatico de prueba";

            t.Persist();

        }
        /*
        [TestMethod]
        public void AltaPrestador()
        {
            Entities.InterAsisst.Prestador p = new Entities.InterAsisst.Prestador();

            p.Nombre = "Remolques Zarate-Brazolargo " + Guid.NewGuid().ToString();
            p.IdPais = 1;
            p.IdProvincia = 1;
            p.IdCiudad = 5;

            p.Descripcion = "Hace todo tipo de remolque";
            p.Activo = true;
            p.Domicilio = "Fuentes 1425";
            p.Telefono1 = "49011564";
            p.Telefono2 = "44322577";
            p.Celular1 = "15 5120 1617";
            p.Celular2 = "15 4676 2120";
            p.Nextel = "4566*135";
            p.Email = "acorallo@gmail.com";
            p.Cuit = "20-26338737-7";
            p.Iva = "Responsable Inscripto";
            p.LIV_MOVIDA = null;
            p.LIV_KM = 100.00f;
            p.SP1_MOVIDA = 240.70f;
            p.SP1_KM = 75.600f;
            p.SP2_MOVIDA = 370f;
            p.SP2_KM = 60.90f;
            p.PS1_MOVIDA = 380.30f;
            p.PS1_KM = 410.30f;
            p.PS2_MOVIDA = 380.15f;
            p.PS2_KM = 450.30f;

            p.Persist();


        }
        */

        [TestMethod]
        public void TipoServicio()
        {
            TipoServicioDS ds = new TipoServicioDS();
            FiltroTipoServicio ft = new FiltroTipoServicio();
            ft.OrderBY = "order by DESCRIPCION ASC";

            ds.List(ft);

        }


    }
}
