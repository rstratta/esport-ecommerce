using ESport.Data.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ESport.Data.Repository.Test
{
    [TestClass]
    
    public class CartRepositoryTest
    {

        CartRepository cartRepository;
        Cart cartTest;
        Product product;
        User user;

        public CartRepositoryTest()
        {
            cartRepository = new CartRepository();
            ProductRepository prodRepo = new ProductRepository();
            UserRepository userRepo = new UserRepository();
            CleanRepositoryHelperTest.CleanDB();

            cartTest = new Cart();

            cartTest.DeliveryAddress = "Ejido 209";
            cartTest.Items = new List<CartItem>();
            cartTest.State = Cart.INIT_CART ;
            product = new Product("1", "campera","negra", 232, "nike");
            prodRepo.AddEntity(product);
            CartItem item = new CartItem(product, 2);
            item.Cart = cartTest;
            cartTest.Items.Add(item);
            user = new User("asapelli", "agus", "Sapelli", "assqw2", "ejido 232", "x@x.com", "23232321");
            userRepo.AddEntity(user);
            cartTest.User = user;
        }

          

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryAddCartException()
        {
            cartRepository.AddEntity(cartTest);
            cartRepository.AddEntity(cartTest);
        }

           [TestMethod]
           public void TestRepositoryAddMultipleCarts()
           {
               Cart cart = new Cart();
               cart.DeliveryAddress = "Ejido 209";
               cart.Items = new List<CartItem>();
               cart.State = "I";
               cart.Total = 2422;
               cart.Opendate = new DateTime(2017, 3, 30);
               CartItem cartItem = new CartItem(product, 2);
               cart.Items.Add(cartItem);
               cart.User = user;
               cartRepository.AddEntity(cartTest);
               cartRepository.AddEntity(cart);
               List<Cart> list = cartRepository.GetAllEntities();
               Assert.IsTrue(list.Contains(cartTest) && list.Contains(cart));
           }


        [TestMethod]
        public void TestRepositoryGetAllCartsWhenNoCartsAreStored()
        {
            List<Cart> expectedReviews = cartRepository.GetAllEntities();
            Assert.AreEqual(0, expectedReviews.Count());
        }

        [TestMethod]
        public void TestRepositoryGetAllEntities()
        {
            cartRepository.AddEntity(cartTest);
            Assert.IsTrue(cartRepository.GetAllEntities().Contains(cartTest));
        }

        [TestMethod]
        public void TestRepositoryUpdateCart()
        {
            int NEW_TOTAL = 60000;
            cartRepository.AddEntity(cartTest);
            cartTest.Total = NEW_TOTAL;
            cartRepository.UpdateEntity(cartTest);
            Cart obtainedCart = cartRepository.GetCurrentCartByUser(cartTest.User);
            Assert.AreEqual(NEW_TOTAL, obtainedCart.Total);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryUpdateUnexistingCart()
        {
            cartRepository.UpdateEntity(cartTest);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryRemoveEntity()
        {
            cartRepository.AddEntity(cartTest);
            cartRepository.RemoveEntity(cartTest);
        }

        [TestMethod]
        public void TestRepositoryGetCurrentCartByUser()
        {
            cartRepository.AddEntity(cartTest);
            Cart currentCart = cartRepository.GetCurrentCartByUser(cartTest.User);
            Assert.AreEqual(currentCart, cartTest);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryGetCurrentCartByUnexistingUser()
        {
            User user = new User("asapellid","agu","sape","ad24","ejido234","324as@h.com","5345");
            Cart currentCart = cartRepository.GetCurrentCartByUser(user);
        }

        [TestMethod]
        public void TestRepositoryAllCartItemsPendingOfReview()
        {
            int result = 0;
            cartRepository.AddEntity(cartTest);
            cartTest.State = Cart.FINISHED_CART;
            cartRepository.UpdateEntity(cartTest);
            List<CartItem> currentCart = cartRepository.AllCartItemsPendingOfReview(cartTest.User);
            foreach (CartItem i in cartTest.Items)
            {
                if (i.PendingReview == true)
                {
                    result++;
                }
            }
            Assert.AreEqual(currentCart.Count, result);
        }

        [TestMethod]
        public void TestRepositoryGetAllCartsByUser()
        {
            cartTest.State = Cart.FINISHED_CART;
            cartRepository.AddEntity(cartTest);
            List<Cart> carts = cartRepository.GetAllCartsByUser(cartTest.User);
            Assert.AreEqual(1, carts.Count);
        }
        }
}
