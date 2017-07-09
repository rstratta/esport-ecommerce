using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESport.Data.Commons;

using ESport.Repository.Stub.Test;
using ESport.Data.Entities;

namespace Esport.Data.Entities.Test
{
    [TestClass]
    
    public class CategoryManagerTest
    {

        ICategoryRepository categoryRepository;
        ICategoryManager categoryManager;
        IProductRepository productRepository;
        CategoryRequest request;
        string CATEGORY_ID = "1";
        string CATEGORY_DESC = "Vestimenta";
        string PRODUCT_ID = "1";
        bool ELIMINATED = false;


        public CategoryManagerTest()
        {
            categoryRepository = new StubCategoryRepository();
            productRepository = new StubProductRepository();
            string PRODUCT_DESC = "IPad";
            double PRODUCT_PRICE = 23.50;
            string PRODUCT_FACTORY = "Apple";
            string PRODUCT_NAME = "Tablet";
            Product product = new Product(PRODUCT_ID, PRODUCT_NAME,PRODUCT_DESC, PRODUCT_PRICE, PRODUCT_FACTORY);
            productRepository.AddEntity(product);
            categoryManager = new CategoryManager(categoryRepository, productRepository);
            request = new CategoryRequest();
            request.CategoryId = CATEGORY_ID;
            request.Description = CATEGORY_DESC;
            request.Eliminated = ELIMINATED;

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
        public void TestAddCategory()
        {
            categoryManager.AddCategory(request);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestAddCategoryRepeat()
        {
            categoryManager.AddCategory(request);
            categoryManager.AddCategory(request);
        }

        [TestMethod]
        public void TestEditcategory()
        {
            categoryManager.AddCategory(request);
            string NEW_DESCRIPTION = "Calzado";
            request.Description = NEW_DESCRIPTION;
            categoryManager.EditCategory(request);
            Category categoryResult = categoryRepository.GetCategoryById(CATEGORY_ID);
            Assert.AreEqual(NEW_DESCRIPTION, categoryResult.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestEditCategoryNotExist()
        {
            categoryManager.EditCategory(request);
        }

        [TestMethod]
        public void TestRemoveCategory()
        {
            categoryManager.AddCategory(request);
            categoryManager.RemoveCategory(request);
            Assert.AreNotEqual(ESportUtils.EMPTY_LIST, categoryRepository.GetAllEntities().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestRemoveCategoryFail()
        {
            categoryManager.RemoveCategory(request);
        }

        [TestMethod]
        public void TestGetAllCategory()
        {
            categoryManager.AddCategory(request);
            Assert.AreNotEqual(ESportUtils.EMPTY_LIST, categoryManager.GetAllCategories().Count);
        }

        [TestMethod]
        public void TestGetAllActivecategories()
        {
            categoryManager.AddCategory(request);
            categoryManager.RemoveCategory(request);
            Assert.AreEqual(ESportUtils.EMPTY_LIST, categoryManager.GetAllActiveCategories().Count);
        }

        [TestMethod]
        public void TestGetCategoryById()
        {
            Category category = new Category();
            category.CategoryId = CATEGORY_ID;
            categoryManager.AddCategory(request);
            Assert.AreEqual(category, categoryManager.GetCategoryById(CATEGORY_ID));
        }

        [TestMethod]
        public void TestAddProductOnCategory()
        {
            categoryManager.AddCategory(request);
            request.ProductId = PRODUCT_ID;
            categoryManager.AddProductOnCategory(request);
            Assert.IsNotNull(productRepository.GetAllProductsByCategoryId(request.CategoryId));
        }
    }
}
