using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESport.Data.Commons;
using ESport.Data.Entities;
using ESport.Repository.Stub.Test;

namespace Esport.Data.Entities.Test
{
    /// <summary>
    /// Descripción resumida de ConfigurationManagerTest
    /// </summary>
    [TestClass]
    public class ConfigurationManagerTest
    {
        PointSystemConfigurationDTO configurationDTO;
        IPointSystemConfigurationManager configurationManager;
        string PROPERTY_NAME = "loyalty";
        double PROPERTY_VALUE = 10;
        public ConfigurationManagerTest()
        {
            configurationManager = new PointSystemConfigurationManager(new StubPointSystemConfigurationRepository());
            configurationDTO = new PointSystemConfigurationDTO();
            configurationDTO.PropertyName= PROPERTY_NAME;
            configurationDTO.PropertyValue = PROPERTY_VALUE;
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
        public void TestAddConfiguration()
        {
            configurationManager.AddConfiguration(configurationDTO);
            Assert.AreNotEqual(ESportUtils.EMPTY_LIST, configurationManager.GetAllConfigurations().Count);
        }

        [TestMethod]
        public void TestRemoveConfiguration()
        {
            configurationManager.AddConfiguration(configurationDTO);
             configurationManager.RemoveConfiguration(configurationDTO);
            Assert.AreEqual(ESportUtils.EMPTY_LIST, configurationManager.GetAllConfigurations().Count);
        }

        [TestMethod]
        public void TestUpdateConfiguration()
        {
            configurationManager.AddConfiguration(configurationDTO);
            configurationDTO.PropertyValue = 0;
            configurationManager.UpdateConfiguration(configurationDTO);
            PointSystemConfiguration result = configurationManager.GetByPropertyName(PROPERTY_NAME);
            Assert.AreEqual(0, result.PropertyValue);
        }
    }
}
