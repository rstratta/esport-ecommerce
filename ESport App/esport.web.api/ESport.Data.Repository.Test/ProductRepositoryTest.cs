using ESport.Data.Entities;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ESport.Data.Repository.Test
{
    [TestClass]
    
    public class ProductRepositoryTest
    {
        ProductRepository productRepository;
        Product productTest;

        public ProductRepositoryTest()
        {
            productRepository = new ProductRepository();
            productTest = new Product("1","remeras", "manga larga", 1093, "zara");
            CleanRepositoryHelperTest.CleanDB();
        }

        [TestMethod]
        public void TestRepositoryAddProduct()
        {
            productRepository.AddEntity(productTest);
            Assert.IsTrue(productTest.Equals(productRepository.GetProductById(productTest.ProductId)));
        }

        [TestMethod]
        public void TestRepositoryAddProductWithCategory()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            Category categoryTest = new Category("categoryTestid", "categoryTestDesc");
            categoryRepository.AddEntity(categoryTest);
            productTest.Category = categoryTest;
            productRepository.AddEntity(productTest);
            Assert.IsNotNull(productRepository.GetProductById(productTest.ProductId).Category);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryAddProductExcpetion()
        {
            productRepository.AddEntity(productTest);
            productRepository.AddEntity(productTest);
        }

        [TestMethod]
        public void TestRepositoryAddMultipleProducts()
        {
            Product newProduct = new Product("2", "gorros", "tela", 1093, "nike");

            productRepository.AddEntity(productTest);
            productRepository.AddEntity(newProduct);

            List<Product> expectedUsers = new List<Product> { productTest, newProduct };
            List<Product> list = productRepository.GetAllEntities();
            Assert.IsTrue(list.Contains(productTest) && list.Contains(newProduct));
        }

        [TestMethod]
        public void TestRepositoryGetAllActiveProducts()
        {
            productRepository.AddEntity(productTest);
            Assert.IsTrue(productRepository.GetAllActiveProducts().Contains(productTest));
        }

        [TestMethod]
        public void TestRepositoryGetAllActiveProductsWhenNoProductsAreStored()
        {
            List<Product> expectedProducts = productRepository.GetAllActiveProducts();
            Assert.AreEqual(0, expectedProducts.Count());
        }

        [TestMethod]
        public void TestRepositoryGetAllProducts()
        {
            productRepository.AddEntity(productTest);
           Assert.IsTrue(productRepository.GetAllEntities().Contains(productTest));
        }

        [TestMethod]
        public void TestRepositoryGetAllEntitiesWhenNoProductsAreStored()
        {
            List<Product> expectedProducts = productRepository.GetAllEntities();
            Assert.AreEqual(0, expectedProducts.Count());
        }

        [TestMethod]
        public void TestRepositoryGetProductById()
        {
            productRepository.AddEntity(productTest);
            Product p = productRepository.GetProductById(productTest.ProductId);
            Assert.IsTrue(productTest.Equals(p));
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryGetUnexistingProductById()
        {
            string ProductId = "sandalias";
            Product p = productRepository.GetProductById(ProductId);
        }

        [TestMethod]
        public void TestRepositoryUpdateProduct()
        {
            string NEW_DESCRIPTION = "medias";
            productRepository.AddEntity(productTest);
            productTest.Description = NEW_DESCRIPTION;
            productRepository.UpdateEntity(productTest);
            Product obtainedProduct = productRepository.GetProductById(productTest.ProductId);
            Assert.IsTrue(NEW_DESCRIPTION.Equals(obtainedProduct.Description));
        }

        [TestMethod]
        public void TestRepositoryUpdateProductAddCategory()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            Category categoryTest = new Category("categoryTestid", "categoryTestDesc");
            categoryRepository.AddEntity(categoryTest);
            productRepository.AddEntity(productTest);
            productTest.Category = categoryTest;
            productRepository.UpdateEntity(productTest);
            Product obtainedProduct = productRepository.GetProductById(productTest.ProductId);
            Assert.IsNotNull(obtainedProduct.Category);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryUpdateUnexistingProduct()
        {
            productRepository.UpdateEntity(productTest);
        }

        [TestMethod]
        public void TestRepositoryRemoveProduct()
        {
            productRepository.AddEntity(productTest);
            productRepository.RemoveEntity(productTest);
            Assert.AreEqual(0, productRepository.GetAllActiveProducts().Count());
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryRemoveUnexistingEntity()
        {
            productRepository.RemoveEntity(productTest);
        }


       
    }
}
