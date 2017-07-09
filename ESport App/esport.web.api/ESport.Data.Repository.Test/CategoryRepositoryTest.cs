using ESport.Data.Entities;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ESport.Data.Repository.Test
{

    [TestClass]
    
    public class CategoryRepositoryTest
    {
        CategoryRepository categoryRepository;
        Category categoryTest;
        public CategoryRepositoryTest()
        {
            categoryRepository = new CategoryRepository();
            categoryTest = new Category("Abrigo", "Para damas, caballeros y ninos");
            CleanRepositoryHelperTest.CleanDB();
        }

     
        [TestMethod]
        public void TestRepositoryAddCategory()
        {
            categoryRepository.AddEntity(categoryTest);
            Assert.IsTrue(categoryTest.Equals(categoryRepository.GetCategoryById(categoryTest.CategoryId)));
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryAddCategoryException()
        {
            categoryRepository.AddEntity(categoryTest);
            Category category2 = new Category("Abrigo", "Para damas, caballeros y ninos");
            categoryRepository.AddEntity(category2);
        }

        [TestMethod]
        public void TestRepositoryAddMultipleCategories()
        {
            Category category = new Category("33333", "Ana");
            categoryRepository.AddEntity(categoryTest);
            categoryRepository.AddEntity(category);

            List<Category> list = categoryRepository.GetAllEntities();
            Assert.IsTrue(list.Contains(categoryTest) && list.Contains(category));
        }

        [TestMethod]
        public void TestRepositoryGetAllActiveCategories()
        {
            categoryRepository.AddEntity(categoryTest);
             Assert.IsTrue(categoryRepository.GetAllActiveCategories().Contains(categoryTest));
        }

        [TestMethod]
        public void TestRepositoryGetAllActiveCategoriesWhenNoCategoriesAreStored()
        {
            List<Category> expectedCategories = categoryRepository.GetAllActiveCategories();
            Assert.AreEqual(0, expectedCategories.Count());
        }

        [TestMethod]
        public void TestRepositoryGetAllEntities()
        {
            categoryRepository.AddEntity(categoryTest);
            Assert.IsTrue(categoryRepository.GetAllEntities().Contains(categoryTest));
        }

        [TestMethod]
        public void TestRepositoryGetAllEntitiesWhenNoCategoriesAreStored()
        {
            List<Category> expectedCategories = categoryRepository.GetAllEntities();
            Assert.AreEqual(0, expectedCategories.Count());
        }

        [TestMethod]
        public void TestRepositoryGetCategoryById()
        {
            categoryRepository.AddEntity(categoryTest);
            Category c = categoryRepository.GetCategoryById(categoryTest.CategoryId);
            Assert.IsTrue(categoryTest.Equals(c));
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryGetUnexistingCategoryById()
        {
            string CategoryId = "Pelotas";
            Category c = categoryRepository.GetCategoryById(CategoryId);
        }

        [TestMethod]
        public void TestRepositoryUpdateCategory()
        {
            string NEW_DESCRIPTION = "Abrigos solo para damas";
            categoryRepository.AddEntity(categoryTest);
            categoryTest.Description = NEW_DESCRIPTION;
            categoryRepository.UpdateEntity(categoryTest);
            Category obtainedCategory = categoryRepository.GetCategoryById(categoryTest.CategoryId);
            Assert.IsTrue(NEW_DESCRIPTION.Equals(obtainedCategory.Description));
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryUpdateUnexistingCategory()
        {
            categoryRepository.UpdateEntity(categoryTest);
        }

        [TestMethod]
        public void TestRepositoryRemoveEntity()
        {
            categoryRepository.AddEntity(categoryTest);
            categoryRepository.RemoveEntity(categoryTest);
            Assert.AreEqual(0, categoryRepository.GetAllActiveCategories().Count());
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryRemoveUnexistingEntity()
        {
            categoryRepository.RemoveEntity(categoryTest);
        }

    }
}