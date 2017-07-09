using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESport.Data.Commons;

using ESport.Repository.Stub.Test;
using ESport.Data.Entities;

namespace ESport.Data.Service.Test
{
    [TestClass]
    
    public class ProductServiceTest
    {
        IProductService productService;
        IProductRepository productRepository;
        IFieldRepository fieldRepository;
        IProductManager productManager;
        ProductRequest request;
        string PRODUCT_ID = "123";
        string PRODUCT_DESC = "IPad";
        double PRODUCT_PRICE = 23.50;
        string PRODUCT_FACTORY = "Apple";
        string PRODUCT_NAME = "Tablet";


        public ProductServiceTest()
        {
            productRepository = new StubProductRepository();
            fieldRepository = new StubFieldRepository();
            productManager = new ProductManager(productRepository, fieldRepository);
            request = new ProductRequest();
            request.ProductId = PRODUCT_ID;
            request.Description = PRODUCT_DESC;
            request.Factory = PRODUCT_FACTORY;
            request.Price = PRODUCT_PRICE;
            request.ProductName = PRODUCT_NAME;
            productService = new ProductServiceImpl(productManager, new SimpleProductDTOBuilder(new ImageDTOBuilder()), new FullProductDTOBuilder(new FieldDTOBuilder(), new ImageDTOBuilder()));
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
        public void TestAddProduct()
        {
            productService.AddProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddProductExceptionProductId()
        {
            request.ProductId = " ";
            productService.AddProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddProductExceptionProductDescription()
        {
            request.Description = null;
            productService.AddProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddProductExceptionProductPrice()
        {
            request.Price = -1;
            productService.AddProduct(request);
        }

        [TestMethod]
        public void TestUpdateProduct()
        {
            productService.AddProduct(request);
            productService.UpdateProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestUpdateProductExceptionProductId()
        {
            request.ProductId = " ";
            productService.UpdateProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestUpdateProductExceptionProductDescription()
        {
            request.Description = null;
            productService.UpdateProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestUpdateProductExceptionProductPrice()
        {
            request.Price = -1;
            productService.UpdateProduct(request);
        }

        [TestMethod]
        public void TestRemoveProduct()
        {
            productService.AddProduct(request);
            productService.RemoveProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestRemoveProductExceptionProductId()
        {
            request.ProductId = " ";
            productService.RemoveProduct(request);
        }

        [TestMethod]
        public void TestRemoveProductExceptionProductDescription()
        {
            productService.AddProduct(request);
            request.Description = null;
            productService.RemoveProduct(request);
        }

        [TestMethod]
        public void TestRemoveProductExceptionProductPrice()
        {
            productService.AddProduct(request); 
            request.Price = -1;
            productService.RemoveProduct(request);
        }

        [TestMethod]
        public void TestGetAllSimpleProducts()
        {
            productService.AddProduct(request);
            List<SimpleProductDTO> result = productService.GetAllSimpleProducts();
            Assert.AreNotEqual(ESportUtils.EMPTY_LIST, result.Count);
        }

        [TestMethod]
        public void TestGetAllSimpleProductsEmpty()
        {
            productService.AddProduct(request);
            productService.RemoveProduct(request);
            List<SimpleProductDTO> result = productService.GetAllSimpleProducts();
            Assert.AreEqual(ESportUtils.EMPTY_LIST, result.Count);
        }

        [TestMethod]
        public void TestGetAllFullProducts()
        {
            productService.AddProduct(request);
            List<FullProductDTO> result = productService.GetAllFullProducts();
            Assert.AreNotEqual(ESportUtils.EMPTY_LIST, result.Count);
        }

        [TestMethod]
        public void TestGetAllFullProductsTwo()
        {
            productService.AddProduct(request);
            productService.RemoveProduct(request);
            List<FullProductDTO> result = productService.GetAllFullProducts();
            Assert.AreNotEqual(ESportUtils.EMPTY_LIST, result.Count);
        }

        [TestMethod]
        public void TestGetAllActiveFullProducts()
        {
            productService.AddProduct(request);
            List<FullProductDTO> result = productService.GetAllActiveFullProducts();
            Assert.AreNotEqual(ESportUtils.EMPTY_LIST, result.Count);
        }

        [TestMethod]
        public void TestGetAllActiveFullProductsEmpty()
        {
            productService.AddProduct(request);
            productService.RemoveProduct(request);
            List<FullProductDTO> result = productService.GetAllActiveFullProducts();
            Assert.AreEqual(ESportUtils.EMPTY_LIST, result.Count);
        }

        [TestMethod]
        public void TestAddFieldOnProduct()
        {
            string FIELD_NAME = "Color";
            string FIELD_TYPE = "string";
            string FIELD_VALUE = "Rojo";
            productService.AddProduct(request);
            request.FieldName = FIELD_NAME;
            request.FieldType = FIELD_TYPE;
            request.FieldValue = FIELD_VALUE;
            productService.AddFieldOnProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddFieldOnProductFieldNameException()
        {
            string FIELD_TYPE = "string";
            string FIELD_VALUE = "Rojo";
            productService.AddProduct(request);
            request.FieldType = FIELD_TYPE;
            request.FieldValue = FIELD_VALUE;
            productService.AddFieldOnProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddFieldOnProductFieldTypeException()
        {
            string FIELD_NAME = "Color";
            string FIELD_VALUE = "Rojo";
            productService.AddProduct(request);
            request.FieldName = FIELD_NAME;
            request.FieldValue = FIELD_VALUE;
            productService.AddFieldOnProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddFieldOnProductFieldValueException()
        {
            string FIELD_NAME = "Color";
            string FIELD_TYPE = "string";
            productService.AddProduct(request);
            request.FieldName = FIELD_NAME;
            request.FieldType = FIELD_TYPE;
            productService.AddFieldOnProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddFieldOnProductProductIdException()
        {
            string FIELD_NAME = "Color";
            string FIELD_TYPE = "string";
            string FIELD_VALUE = "Rojo";
            productService.AddProduct(request);
            request.ProductId = null;
            request.FieldName = FIELD_NAME;
            request.FieldType = FIELD_TYPE;
            request.FieldValue = FIELD_VALUE;
            productService.AddFieldOnProduct(request);
        }

        [TestMethod]
        public void TestEditFieldOnProduct()
        {
            string FIELD_NAME = "Color";
            string FIELD_TYPE = "string";
            string FIELD_VALUE = "Rojo";
            productService.AddProduct(request);
            request.FieldName = FIELD_NAME;
            request.FieldType = FIELD_TYPE;
            request.FieldValue = FIELD_VALUE;
            productService.AddFieldOnProduct(request);
            request.FieldType = null;
            productService.EditFieldOnProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestEditFieldOnProductFieldNameException()
        {
            string FIELD_NAME = "Color";
            string FIELD_TYPE = "string";
            string FIELD_VALUE = "Rojo";
            productService.AddProduct(request);
            request.FieldName = FIELD_NAME;
            request.FieldType = FIELD_TYPE;
            request.FieldValue = FIELD_VALUE;
            productService.AddFieldOnProduct(request);
            request.FieldType = null;
            request.FieldName = null;
            productService.EditFieldOnProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestEditFieldOnProductFieldValueException()
        {
            string FIELD_NAME = "Color";
            string FIELD_TYPE = "string";
            string FIELD_VALUE = "Rojo";
            productService.AddProduct(request);
            request.FieldName = FIELD_NAME;
            request.FieldType = FIELD_TYPE;
            request.FieldValue = FIELD_VALUE;
            productService.AddFieldOnProduct(request);
            request.FieldType = null;
            request.FieldValue = null;
            productService.EditFieldOnProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestEditFieldOnProductProductIdException()
        {
            string FIELD_NAME = "Color";
            string FIELD_TYPE = "string";
            string FIELD_VALUE = "Rojo";
            productService.AddProduct(request);
            request.FieldName = FIELD_NAME;
            request.FieldType = FIELD_TYPE;
            request.FieldValue = FIELD_VALUE;
            productService.AddFieldOnProduct(request);
            request.ProductId = null;
            request.FieldName = null;
            productService.EditFieldOnProduct(request);
        }

        [TestMethod]
        public void TestRemoveFieldOnProduct()
        {
            string FIELD_NAME = "Color";
            string FIELD_TYPE = "string";
            string FIELD_VALUE = "Rojo";
            productService.AddProduct(request);
            request.FieldName = FIELD_NAME;
            request.FieldType = FIELD_TYPE;
            request.FieldValue = FIELD_VALUE;
            productService.AddFieldOnProduct(request);
            productService.RemoveFieldOnProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestRemoveFieldOnProductFieldNameException()
        {
            string FIELD_NAME = "Color";
            string FIELD_TYPE = "string";
            string FIELD_VALUE = "Rojo";
            productService.AddProduct(request);
            request.FieldName = FIELD_NAME;
            request.FieldType = FIELD_TYPE;
            request.FieldValue = FIELD_VALUE;
            productService.AddFieldOnProduct(request);
            request.FieldName = null;
            productService.RemoveFieldOnProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestRemoveFieldOnProductProductIdException()
        {
            string FIELD_NAME = "Color";
            string FIELD_TYPE = "string";
            string FIELD_VALUE = "Rojo";
            productService.AddProduct(request);
            request.FieldName = FIELD_NAME;
            request.FieldType = FIELD_TYPE;
            request.FieldValue = FIELD_VALUE;
            productService.AddFieldOnProduct(request);
            request.ProductId = null;
            productService.RemoveFieldOnProduct(request);
        }
    }
}
