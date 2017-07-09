using ESport.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Esport.Data.Entities.Test
{
    [TestClass]
    
    public class CategoryTest
    {
        public CategoryTest()
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
        public void TestCategoryId()
        {
            string CATEGORY_ROOT_ID = "root";
            Category category = new Category();
            category.CategoryId = CATEGORY_ROOT_ID;
            Assert.AreEqual(CATEGORY_ROOT_ID, category.CategoryId);
        }

        [TestMethod]
        public void TestCategoryDescription()
        {
            string CATEGORY_DESCRIPTION = "phones";
            Category category = new Category();
            category.Description = CATEGORY_DESCRIPTION;
            Assert.AreEqual(CATEGORY_DESCRIPTION, category.Description);
        }

        [TestMethod]
        public void TestCategoryEliminated()
        {
            Category category = new Category();
            Assert.IsFalse(category.Eliminated);
        }

        [TestMethod]
        public void TestCategoryProducts()
        {
            Category category = new Category();
            Assert.IsFalse(category.HasProducts());
        }

        [TestMethod]
        public void TestCategoryConstructorWithParamsOne()
        {            
            string CATEGORY_ROOT_ID = "root";
            string CATEGORY_DESCRIPTION = "phones";
            Category category = new Category(CATEGORY_ROOT_ID, CATEGORY_DESCRIPTION);
            Assert.AreEqual(CATEGORY_ROOT_ID, category.CategoryId);
        }

        [TestMethod]
        public void TestCategoryConstructorWithParamsTwo()
        {
            string CATEGORY_ROOT_ID = "root";
            string CATEGORY_DESCRIPTION = "phones";
            Category category = new Category(CATEGORY_ROOT_ID, CATEGORY_DESCRIPTION);
            Assert.AreEqual(CATEGORY_DESCRIPTION, category.Description);
        }

        [TestMethod]
        public void TestCategoryConstructorWithParamsThree()
        {
            string CATEGORY_ROOT_ID = "root";
            string CATEGORY_DESCRIPTION = "phones";
            Category category = new Category(CATEGORY_ROOT_ID, CATEGORY_DESCRIPTION);
            Assert.IsFalse(category.Eliminated);
        }

        [TestMethod]
        public void TestCategoryConstructorWithParamsFour()
        {
            string CATEGORY_ROOT_ID = "root";
            string CATEGORY_DESCRIPTION = "phones";
            Category category = new Category(CATEGORY_ROOT_ID, CATEGORY_DESCRIPTION);
            Assert.IsFalse(category.HasProducts());
        }
        [TestMethod]
        public void TestCategoryAddProduct()
        {
            Category category = new Category();
            category.AddProduct(new Product());
            Assert.IsTrue(category.HasProducts());
        }

        [TestMethod]
        public void TestCategorySetEliminated()
        {
            Category category = new Category();
            category.Eliminated = true;
            Assert.IsTrue(category.Eliminated);
        }
    }
}
