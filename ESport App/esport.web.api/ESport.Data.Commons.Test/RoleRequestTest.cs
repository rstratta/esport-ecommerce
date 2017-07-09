using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ESport.Data.Commons.Test
{
    [TestClass]
    public class RoleRequestTest
    {
        public RoleRequestTest()
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
        public void TestRoleRequestRoleId()
        {
            string ROLE_ID = "admin";
            RoleRequest request = new RoleRequest();
            request.RoleId = ROLE_ID;
            Assert.AreEqual(ROLE_ID, request.RoleId);
        }

        [TestMethod]
        public void TestRoleRequestRoleDescription()
        {
            string ROLE_DESCRIPTION = "Administrador de Sistema";
            RoleRequest request = new RoleRequest();
            request.Description = ROLE_DESCRIPTION;
            Assert.AreEqual(ROLE_DESCRIPTION, request.Description);
        }
    }
}
