using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESport.Repository.Stub.Test;
using ESport.Data.Commons;

using ESport.Data.Entities;

namespace ESport.Data.Service.Test
{
    [TestClass]
    
    public class CategoryServiceTest
    {
        ICategoryService categoryService;
        CategoryRequest request;
        string PRODUCT_ID = "1";
        public CategoryServiceTest()
        {
            string PRODUCT_DESC = "IPad";
            double PRODUCT_PRICE = 23.50;
            string PRODUCT_FACTORY = "Apple";
            string PRODUCT_NAME = "Tablet";
            ICategoryRepository categoryRepository = new StubCategoryRepository();
            IProductRepository productRepository = new StubProductRepository();
            Product product = new Product(PRODUCT_ID, PRODUCT_NAME, PRODUCT_DESC, PRODUCT_PRICE, PRODUCT_FACTORY);
            productRepository.AddEntity(product);
            request = new CategoryRequest();
            request.CategoryId = "vest.";
            request.Description = "Vestimenta";
            request.ProductId = PRODUCT_ID;
            ICategoryManager categoryManager = new CategoryManager(categoryRepository, productRepository);
            categoryService = new CategoryServiceImpl(categoryManager, new CategoryBuilderDTO(new FullProductDTOBuilder(new FieldDTOBuilder(),new ImageDTOBuilder())));
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
            categoryService.AddCategory(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddCategoryCategoryIdException()
        {
            request.CategoryId = null;
            categoryService.AddCategory(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddCategoryCategoryDescException()
        {
            request.Description = null;
            categoryService.AddCategory(request);
        }

        [TestMethod]
        public void TestEditCategory()
        {
            string NEW_DESCRIPTION = "newDesc";
            categoryService.AddCategory(request);
            request.Description = NEW_DESCRIPTION;
            categoryService.EditCategory(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestEditCategoryCategoryIdException()
        {
            categoryService.AddCategory(request);
            request.CategoryId = null;
            categoryService.EditCategory(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestEditCategoryCategoryDescException()
        {
            categoryService.AddCategory(request);
            request.Description = null;
            categoryService.EditCategory(request);
        }

        [TestMethod]
        public void TestRemoveCategory()
        {
            categoryService.AddCategory(request);
            categoryService.RemoveCategory(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestRemoveCategoryCategoryIdException()
        {
            categoryService.AddCategory(request);
            request.CategoryId = null;
            categoryService.RemoveCategory(request);
        }
        [TestMethod]
        public void TestAddProductOnCategory()
        {
            categoryService.AddCategory(request);
            categoryService.AddProductOnCategory(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestCategoryCategoryIdException()
        {
            categoryService.AddCategory(request);
            request.CategoryId = null;
            categoryService.AddProductOnCategory(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddProductOnCategoryProductIdException()
        {
            categoryService.AddCategory(request);
            request.ProductId = null;
            categoryService.AddProductOnCategory(request);
        }

        [TestMethod]
        public void TestGetAllCategories()
        {
            categoryService.AddCategory(request);
            List<CategoryDTO> result = categoryService.GetAllCategories();
            Assert.AreNotEqual(ESportUtils.EMPTY_LIST, result.Count);
        }

        [TestMethod]
        public void TestGetAllActiveCategories()
        {
            categoryService.AddCategory(request);
            List<CategoryDTO> result = categoryService.GetAllActiveCategories();
            Assert.AreNotEqual(ESportUtils.EMPTY_LIST, result.Count);
        }

        [TestMethod]
        public void TestGetAllActiveCategoriesTwo()
        {
            categoryService.AddCategory(request);
            categoryService.RemoveCategory(request);
            List<CategoryDTO> result = categoryService.GetAllActiveCategories();
            Assert.AreEqual(ESportUtils.EMPTY_LIST, result.Count);
        }

        [TestMethod]
        public void TestGetAllProductsByCategory()
        {
            categoryService.AddCategory(request);
            List<FullProductDTO> result = categoryService.GetProductsByCategoryId(request);
            Assert.AreEqual(ESportUtils.EMPTY_LIST, result.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestGetAllProductsByCategoryRequestException()
        {
            categoryService.AddCategory(request);
            request.CategoryId = null;
            List<FullProductDTO> result = categoryService.GetProductsByCategoryId(request);
        }
    }
}
