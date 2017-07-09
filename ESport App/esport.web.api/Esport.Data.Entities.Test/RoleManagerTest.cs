using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESport.Repository.Stub.Test;
using ESport.Data.Commons;

using ESport.Data.Entities;

namespace Esport.Data.Entities.Test
{

    [TestClass]
    
    public class RoleManagerTest
    {
        RoleRequest roleRequest;
        IRoleRepository mockRoleRepository;
        IRoleManager roleManager;
        string ROLE_ID = "admin";
        string ROLE_DESCRIPTION = "Administrador de sistemas";

        public RoleManagerTest()
        {
            roleRequest = new RoleRequest();
            roleRequest.RoleId = ROLE_ID;
            roleRequest.Description = ROLE_DESCRIPTION;
            mockRoleRepository = new StubRoleRepository();
            roleManager = new RoleManager(mockRoleRepository);
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
        public void TestAddRole()
        {
            roleManager.AddRole(roleRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestAddRoleRepeat()
        {
            roleManager.AddRole(roleRequest);
            roleManager.AddRole(roleRequest);
        }

        [TestMethod]
        public void TestEditRole()
        {
            roleManager.AddRole(roleRequest);
            string NEW_DESCRIPTION = "Administrador";
            roleRequest.Description = NEW_DESCRIPTION;
            roleManager.UpdateRole(roleRequest);
            Role roleResult = mockRoleRepository.GetRoleById(ROLE_ID);
            Assert.AreEqual(NEW_DESCRIPTION, roleResult.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestEditRoleNotExist()
        {
            roleManager.UpdateRole(roleRequest);
        }

        [TestMethod]
        public void TestRemoveRole()
        {
            roleManager.AddRole(roleRequest);
            roleManager.RemoveRole(roleRequest);
            Assert.AreNotEqual(ESportUtils.EMPTY_LIST, mockRoleRepository.GetAllEntities().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestRemoveRoleFail()
        {
            roleManager.RemoveRole(roleRequest);
        }

        [TestMethod]
        public void TestGetAllRoles()
        {
            roleManager.AddRole(roleRequest);
            Assert.AreNotEqual(ESportUtils.EMPTY_LIST, roleManager.GetAllRoles().Count);
        }

        [TestMethod]
        public void TestGetAllActiveRoles()
        {
            roleManager.AddRole(roleRequest);
            roleManager.RemoveRole(roleRequest);
            Assert.AreEqual(ESportUtils.EMPTY_LIST, roleManager.GetAllActiveRoles().Count);
        }

        [TestMethod]
        public void TestGetRoleById()
        {
            Role role = new Role();
            role.RoleId = ROLE_ID;
            role.Description = ROLE_DESCRIPTION;
            roleManager.AddRole(roleRequest);
            Assert.AreEqual(role, roleManager.GetRoleById(ROLE_ID));
        }
    }
}
