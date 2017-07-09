using ESport.Data.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ESport.Data.Repository.Test
{

    [TestClass]
    
    public class ReviewRepositoryTest
    {
        ReviewRepository reviewRepository;
        Review reviewTest;
        User user2;
        Product product2;
        User user;
        Product product;

        public ReviewRepositoryTest()
        {
            reviewRepository = new ReviewRepository();

            UserRepository userRepository = new UserRepository();
            ProductRepository productRepository = new ProductRepository();
            CleanRepositoryHelperTest.CleanDB();
            user = new User("asapelli", "agustina", "Sapelli", "29iedi3", "ejido 1932", "titisapelli@hotmail.com", "26002158");
            userRepository.AddEntity(user);
            user2 = new User("mgonzalez", "mariana", "gonzalez", "29iedi3", "ejido 1932", "titisapelli@hotmail.com", "26002158");
            userRepository.AddEntity(user2);

            
            product = new Product("1","Cinturon", "cinturones de tela", 500, "nike");
            productRepository.AddEntity(product);
            product2 = new Product("2","Medias", "medias para correr", 500, "nike");
            productRepository.AddEntity(product2);

            reviewTest = new Review(user, product, "Descripcion de la review", 8);
            

            
        }

        [TestMethod]
        public void TestRepositoryAddReview()
        {
            reviewRepository.AddEntity(reviewTest);
            Review expectedReview= reviewRepository.GetReviewById(reviewTest.Id);
            Assert.AreEqual(reviewTest, expectedReview);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryAddReviewException()
        {
            reviewRepository.AddEntity(reviewTest);
            reviewRepository.AddEntity(reviewTest);
        }

        [TestMethod]
        public void TestRepositoryAddMultipleReviews()
        {
            Review review = new Review(reviewTest.User, reviewTest.Product, "Descripcion de la review", 8);
            reviewRepository.AddEntity(reviewTest);
            reviewRepository.AddEntity(review);

            List<Review> list = reviewRepository.GetAllEntities();
            Assert.IsTrue(list.Contains(reviewTest) && list.Contains(review));
        }

        [TestMethod]
        public void TestRepositoryGetAllReviewsWhenNoReviewsAreStored()
        {
            List<Review> expectedReviews = reviewRepository.GetAllEntities();
            Assert.AreEqual(0, expectedReviews.Count());
        }

        [TestMethod]
        public void TestRepositoryGetAllEntities()
        {
            reviewRepository.AddEntity(reviewTest);
            Assert.IsTrue(reviewRepository.GetAllEntities().Contains(reviewTest));
        }

        [TestMethod]
        public void TestRepositoryGetReviewById()
        {
            reviewRepository.AddEntity(reviewTest);
            Review r = reviewRepository.GetReviewById(reviewTest.Id);
            Assert.IsTrue(reviewTest.Equals(r));
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryGetUnexistingReviewById()
        {
            Guid id = new Guid();
            Review r = reviewRepository.GetReviewById(id);
        }

        [TestMethod]
        public void TestRepositoryUpdateReview()
        {
            string NEW_DESCRIPTION = "Cambiamos la description";
            reviewRepository.AddEntity(reviewTest);
            reviewTest.Description = NEW_DESCRIPTION;
            reviewRepository.UpdateEntity(reviewTest);
            Review obtainedReview = reviewRepository.GetReviewById(reviewTest.Id);
            Assert.IsTrue(NEW_DESCRIPTION.Equals(obtainedReview.Description));
        }


        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryUpdateUnexistingReview()
        {
            reviewRepository.UpdateEntity(reviewTest);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryRemoveEntity()
        {
            reviewRepository.AddEntity(reviewTest);
            reviewRepository.RemoveEntity(reviewTest);
        }

        [TestMethod]
        public void TestRepositoryGetAllByProduct()
        {
            reviewRepository.AddEntity(reviewTest);
            List<Review> reviews = reviewRepository.GetAllByProduct(reviewTest.Product);

        }

        [TestMethod]
        public void TestRepositoryGetAllByUser()
        {
            reviewRepository.AddEntity(reviewTest);
            List<Review> reviews = reviewRepository.GetAllByUser(reviewTest.User);

        }

        [TestMethod]
        public void TestRepositoryGetAllByUnexistingProduct()
        {
            reviewRepository.AddEntity(reviewTest);
            List<Review> reviews = reviewRepository.GetAllByProduct(product2);

        }

        [TestMethod]
        public void TestRepositoryGetAllByUnexistingUser()
        {
            reviewRepository.AddEntity(reviewTest);
            List<Review> reviews = reviewRepository.GetAllByUser(user2);

        }
        
    }
    
}
