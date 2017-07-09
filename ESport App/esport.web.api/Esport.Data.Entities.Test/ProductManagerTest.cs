using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESport.Repository.Stub.Test;
using ESport.Data.Commons;

using System.Linq;
using ESport.Data.Entities;

namespace Esport.Data.Entities.Test
{

    [TestClass]
    
    public class ProductManagerTest
    {
        IProductRepository productRepository;
        IFieldRepository fieldRepository;
        IProductManager productManager;
        ProductRequest request;
        string PRODUCT_ID = "123";
        string PRODUCT_DESC = "IPad";
        double PRODUCT_PRICE = 23.50;
        string PRODUCT_FACTORY = "Apple";

        public ProductManagerTest()
        {
            productRepository = new StubProductRepository();
            fieldRepository = new StubFieldRepository();
            productManager = new ProductManager(productRepository, fieldRepository);
            request = new ProductRequest();
            request.ProductId = PRODUCT_ID;
            request.Description = PRODUCT_DESC;
            request.Factory = PRODUCT_FACTORY;
            request.Price = PRODUCT_PRICE;
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
            productManager.AddProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestAddProductRepeat()
        {
            productManager.AddProduct(request);
            productManager.AddProduct(request);
        }

        [TestMethod]
        public void TestEditProduct()
        {
            productManager.AddProduct(request);
            string NEW_DESCRIPTION = "Tablet";
            request.Description = NEW_DESCRIPTION;
            productManager.EditProduct(request);
            Product productResult = productRepository.GetProductById(PRODUCT_ID);
            Assert.AreEqual(NEW_DESCRIPTION, productResult.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestEditProductNotExist()
        {
            productManager.EditProduct(request);
        }

        [TestMethod]
        public void TestRemoveProduct()
        {
            productManager.AddProduct(request);
            productManager.RemoveProduct(request);
            Assert.AreNotEqual(ESportUtils.EMPTY_LIST, productRepository.GetAllEntities().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestRemoveProductFail()
        {
            productManager.RemoveProduct(request);
        }

        [TestMethod]
        public void TestGetAllProducts()
        {
            productManager.AddProduct(request);
            Assert.AreNotEqual(ESportUtils.EMPTY_LIST, productManager.GetAllProducts().Count);
        }

        [TestMethod]
        public void TestGetAllActiveProducts()
        {
            productManager.AddProduct(request);
            productManager.RemoveProduct(request);
            Assert.AreEqual(ESportUtils.EMPTY_LIST, productManager.GetAllActiveProducts().Count);
        }

        [TestMethod]
        public void TestGetProductById()
        {
            Product product = new Product();
            product.ProductId = PRODUCT_ID;
            productManager.AddProduct(request);
            Assert.AreEqual(product, productManager.GetProductById(PRODUCT_ID));
        }

        [TestMethod]
        public void TestAddFieldOne()
        {
            Product product = new Product();
            product.ProductId = PRODUCT_ID;
            productManager.AddProduct(request);
            Field field = new Field();
            string FIELD_NAME = "Color";
            string FIELD_TYPE = "string";
            string FIELD_VALUE = "Rojo";
            field.Name = FIELD_NAME;
            field.Type = FIELD_TYPE;
            request.FieldName = FIELD_NAME;
            request.FieldType = FIELD_TYPE;
            request.FieldValue = FIELD_VALUE;
            productManager.AddFieldOnProduct(request);
            Assert.AreEqual(productManager.GetProductById(PRODUCT_ID).Fields.Where(f => f.Field.Name==field.Name).First().Value, request.FieldValue);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestAddFieldTwo()
        {
            Product product = new Product();
            product.ProductId = PRODUCT_ID;
            productManager.AddProduct(request);
            Field field = new Field();
            string FIELD_NAME = "Color";
            string FIELD_TYPE = "string";
            string FIELD_VALUE = "Rojo";
            field.Name = FIELD_NAME;
            field.Type = FIELD_TYPE;
            request.FieldName = FIELD_NAME;
            request.FieldType = FIELD_TYPE;
            request.FieldValue = FIELD_VALUE;
            productManager.AddFieldOnProduct(request);
            productManager.AddFieldOnProduct(request);
        }

        [TestMethod]
        public void TestDeleteFieldOne()
        {
            productManager.AddProduct(request);
            Field field = new Field();
            string FIELD_NAME = "Color";
            string FIELD_TYPE = "string";
            string FIELD_VALUE = "Rojo";
            field.Name = FIELD_NAME;
            field.Type = FIELD_TYPE;
            request.FieldName = FIELD_NAME;
            request.FieldType = FIELD_TYPE;
            request.FieldValue = FIELD_VALUE;
            productManager.AddFieldOnProduct(request);
            productManager.DeleteFieldOnProduct(request);
            Assert.AreEqual(0, productManager.GetProductById(PRODUCT_ID).Fields.Count);
        }

        [TestMethod]
        public void TestDeleteFieldTestTwo()
        {
            productManager.AddProduct(request);
            Field field1 = new Field();
            string FIELD_NAME1 = "Color";
            string FIELD_TYPE1 = "string";
            string FIELD_VALUE1 = "Rojo";
            field1.Name = FIELD_NAME1;
            field1.Type = FIELD_TYPE1;
            request.FieldName = FIELD_NAME1;
            request.FieldType = FIELD_TYPE1;
            request.FieldValue = FIELD_VALUE1;
            productManager.AddFieldOnProduct(request);
            Field field2 = new Field();
            string FIELD_NAME2 = "Talle";
            string FIELD_TYPE2 = "int";
            string FIELD_VALUE2 = "32";
            field2.Name = FIELD_NAME2;
            field2.Type = FIELD_TYPE2;
            request.FieldName = FIELD_NAME2;
            request.FieldType = FIELD_TYPE2;
            request.FieldValue = FIELD_VALUE2;
            productManager.AddFieldOnProduct(request);
            productManager.DeleteFieldOnProduct(request);
            Assert.AreEqual(1, productManager.GetProductById(PRODUCT_ID).Fields.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestDeleteFieldThree()
        {
            productManager.AddProduct(request);
            productManager.DeleteFieldOnProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestDeleteFieldFour()
        {
            Product product = new Product();
            product.ProductId = PRODUCT_ID;
            productManager.AddProduct(request);
            request.FieldName = "Talle";
            request.FieldType = "int";
            request.FieldValue = "38";
            productManager.AddFieldOnProduct(request);
            request.FieldName = "Color";
            request.FieldType = "string";
            request.FieldValue = "rojo";
            productManager.DeleteFieldOnProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestModifyFieldTwo()
        {
            Product product = new Product();
            product.ProductId = PRODUCT_ID;
            productManager.AddProduct(request);
            string FIELD_NAME = "Color";
            string FIELD_TYPE = "string";
            string FIELD_VALUE = "Rojo";
            request.FieldName = FIELD_NAME;
            request.FieldType = FIELD_TYPE;
            request.FieldValue = FIELD_VALUE;
            productManager.AddFieldOnProduct(request);
            request.FieldName = "Otro";
            productManager.ModifyFieldOnProduct(request);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestModifyFieldThree()
        {
            Product product = new Product();
            product.ProductId = PRODUCT_ID;
            productManager.AddProduct(request);
            productManager.ModifyFieldOnProduct(request);
        }

     
        [TestMethod]
        public void TestModifyFieldFive()
        {
            Product product = new Product();
            product.ProductId = PRODUCT_ID;
            productManager.AddProduct(request);
            string FIELD_NAME = "Color";
            string FIELD_TYPE = "string";
            string FIELD_VALUE = "Rojo";
            request.FieldName = FIELD_NAME;
            request.FieldType = FIELD_TYPE;
            request.FieldValue = FIELD_VALUE;
            productManager.AddFieldOnProduct(request);
            string NEW_FIELD_VALUE = "Azul";
            request.FieldValue = NEW_FIELD_VALUE;
            productManager.ModifyFieldOnProduct(request);
            Assert.AreEqual(productManager.GetProductById(PRODUCT_ID).Fields.Where(f=>f.Field.Name==request.FieldName).First().Value, NEW_FIELD_VALUE);
        }
    }
}
