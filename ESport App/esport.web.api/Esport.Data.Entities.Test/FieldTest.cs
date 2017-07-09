using ESport.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Esport.Data.Entities.Test
{
    [TestClass]
    
    public class FieldTest
    {
        public FieldTest()
        {
            
        }
        private TestContext testContextInstance;       
       
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
        public void TestFieldName()
        {
            string FIELD_NAME = "Color";
            Field field = new Field();
            field.Name = FIELD_NAME;
            Assert.AreEqual(field.Name, FIELD_NAME);
        }

        [TestMethod]
        public void TestFieldType()
        {
            string FIELD_TYPE = "string";
            Field field = new Field();
            field.Type = FIELD_TYPE;
            Assert.AreEqual(field.Type, FIELD_TYPE);
        }


        [TestMethod]
        public void TestFieldConstructorWithArgumentsOne()
        {
            string FIELD_NAME = "Talle";
            string FIELD_TYPE = "int";
            Field field = new Field(FIELD_NAME, FIELD_TYPE);
            Assert.AreEqual(field.Name, FIELD_NAME);
        }

        [TestMethod]
        public void TestFieldConstructorWithArgumentsTwo()
        {
            string FIELD_NAME = "Talle";
            string FIELD_TYPE = "int";
            Field field = new Field(FIELD_NAME, FIELD_TYPE);
            Assert.AreEqual(field.Type, FIELD_TYPE);
        }

  

    }
}