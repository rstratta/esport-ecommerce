using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESport.Data.Entities;

namespace Esport.Data.Entities.Test
{
    /// <summary>
    /// Descripción resumida de ConfigurationTest
    /// </summary>
    [TestClass]
    public class ConfigurationTest
    {
        public ConfigurationTest()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la serie de pruebas actual.
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

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestPropertyName()
        {
            string PROPERTY_NAME= "loyalty";
            PointSystemConfiguration configuration= new PointSystemConfiguration();
            configuration.PropertyName= PROPERTY_NAME;
            Assert.AreEqual(PROPERTY_NAME, configuration.PropertyName);
        }

        [TestMethod]
        public void TestPropertyValue()
        {
            int PROPERTY_VALUE = 10;
            PointSystemConfiguration configuration = new PointSystemConfiguration();
            configuration.PropertyValue = PROPERTY_VALUE;
            Assert.AreEqual(PROPERTY_VALUE, configuration.PropertyValue);
        }

        [TestMethod]
        public void TestPropertyId()
        {
            PointSystemConfiguration configuration = new PointSystemConfiguration();
            Assert.IsNotNull(configuration.Id);
        }
    }
}
