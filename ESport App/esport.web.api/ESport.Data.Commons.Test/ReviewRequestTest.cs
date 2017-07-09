using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ESport.Data.Commons.Test
{
    [TestClass]
    public class ReviewRequestTest
    {
        public ReviewRequestTest()
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

       
        [TestMethod]
        public void TestReviewRequestProductId()
        {
            string PRODUCT_ID = "1";
            ReviewRequest request = new ReviewRequest();
            request.ProductId = PRODUCT_ID;
            Assert.AreEqual(request.ProductId, PRODUCT_ID);
        }

        [TestMethod]
        public void TestReviewRequestDescription()
        {
            string DESCRIPTION = "Excelente";
            ReviewRequest request = new ReviewRequest();
            request.Description = DESCRIPTION;
            Assert.AreEqual(request.Description, DESCRIPTION);
        }

        [TestMethod]
        public void TestReviewRequestPoints()
        {
            int POINTS = 5;
            ReviewRequest request = new ReviewRequest();
            request.Points = POINTS;
            Assert.AreEqual(request.Points, POINTS);
        }

        [TestMethod]
        public void TestReviewRequestUserId()
        {
            string USER_ID = "admin";
            ReviewRequest request = new ReviewRequest();
            request.UserId = USER_ID;
            Assert.AreEqual(request.UserId, USER_ID);
        }
    }
}
