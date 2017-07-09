using ESport.Data.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Esport.Data.Entities.Test
{
    [TestClass]
    
    public class RoleTest
    {
        public RoleTest()
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
        public void TestRoleId()
        {
            string ROLE_ID = "admin";
            Role role = new Role();
            role.RoleId = ROLE_ID;
            Assert.AreEqual(ROLE_ID, role.RoleId); 
        }

        [TestMethod]
        public void TestRoleDescription()
        {
            string ROLE_DESCRIPTION = "Administrador de Sistema";
            Role role = new Role();
            role.Description = ROLE_DESCRIPTION;
            Assert.AreEqual(ROLE_DESCRIPTION, role.Description);
        }

        [TestMethod]
        public void TestRoleEliminated()
        {
            Role role = new Role();
            Assert.IsFalse(role.Eliminated);
        }

        [TestMethod]
        public void TestRoleConstructorWithArgumentsOne()
        {
            string ROLE_ID = "admin";
            string ROLE_DESCRIPTION = "Administrador de Sistema";
            Role role = new Role(ROLE_ID, ROLE_DESCRIPTION);
            Assert.AreEqual(role.RoleId, ROLE_ID);
        }

        [TestMethod]
        public void TestRoleConstructorWithArgumentsTwo()
        {
            string ROLE_ID = "admin";
            string ROLE_DESCRIPTION = "Administrador de Sistema";
            Role role = new Role(ROLE_ID, ROLE_DESCRIPTION);
            Assert.AreEqual(role.Description, ROLE_DESCRIPTION);
        }

        [TestMethod]
        public void TestRoleConstructorWithArgumentsThree()
        {
            string ROLE_ID = "admin";
            string ROLE_DESCRIPTION = "Administrador de Sistema";
            Role role = new Role(ROLE_ID, ROLE_DESCRIPTION);
            Assert.IsFalse(role.Eliminated);
        }

        [TestMethod]
        public void TestRoleSetEliminated()
        {
            Role role = new Role();
            role.Eliminated = true;
            Assert.IsTrue(role.Eliminated);
        }

    }
}
