using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESport.Repository.Stub.Test;

using ESport.Data.Commons;
using ESport.Data.Entities;

namespace ESport.Data.Service.Test
{
    [TestClass]
    
    public class RoleServiceTest
    {
        IRoleService roleService;
        RoleRequest roleRequest;
        IRoleManager roleManager;
        string ROLE_ID = "admin";
        string ROLE_DESCRIPTION = "Administrador de sistemas";

        public RoleServiceTest()
        {
            roleRequest = new RoleRequest();
            roleManager = new RoleManager(new StubRoleRepository());
            roleService = new RoleServiceImpl(roleManager, new RoleDTOBuilder());
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
            roleRequest.RoleId = ROLE_ID;
            roleRequest.Description = ROLE_DESCRIPTION;
            roleService.AddRole(roleRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddRoleAndValidateRequest()
        {
            roleRequest.Description = ROLE_DESCRIPTION;
            roleService.AddRole(roleRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddRoleAndValidateRequestTwo()
        {
            roleRequest.RoleId = ROLE_ID;
            roleService.AddRole(roleRequest);
        }

        [TestMethod]
        public void TestEditRole()
        {
            roleRequest.RoleId = ROLE_ID;
            roleRequest.Description = ROLE_DESCRIPTION;
            roleService.AddRole(roleRequest);
            string NEW_DESCRIPTION = "newDescription";
            roleRequest.Description = NEW_DESCRIPTION;
            roleService.UpdateRole(roleRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestEditRoleAndValidateRequest()
        {
            roleRequest.RoleId = ROLE_ID;
            roleRequest.Description = ROLE_DESCRIPTION;
            roleService.AddRole(roleRequest);
            roleRequest.RoleId = null;
            roleService.UpdateRole(roleRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestEditRoleAndValidateRequestTwo()
        {
            roleRequest.RoleId = ROLE_ID;
            roleRequest.Description = ROLE_DESCRIPTION;
            roleService.AddRole(roleRequest);
            roleRequest.Description = null;
            roleService.UpdateRole(roleRequest);
        }

        [TestMethod]
        public void TestRemoveRole()
        {
            roleRequest.RoleId = ROLE_ID;
            roleRequest.Description = ROLE_DESCRIPTION;
            roleService.AddRole(roleRequest);
            roleService.RemoveRole(roleRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestRemoveRoleAndValidateRequest()
        {
            roleRequest.RoleId = ROLE_ID;
            roleRequest.Description = ROLE_DESCRIPTION;
            roleService.AddRole(roleRequest);
            roleRequest.RoleId = null;
            roleService.RemoveRole(roleRequest);
        }

        [TestMethod]
        public void TestRemoveRoleAndValidateRequestTwo()
        {
            roleRequest.RoleId = ROLE_ID;
            roleRequest.Description = ROLE_DESCRIPTION;
            roleService.AddRole(roleRequest);
            roleRequest.Description = null;
            roleService.RemoveRole(roleRequest);
        }

        [TestMethod]
        public void TestGetRoleByRoleId()
        {
            roleRequest.RoleId = ROLE_ID;
            roleRequest.Description = ROLE_DESCRIPTION;
            roleService.AddRole(roleRequest);
            RoleDTO result = roleService.GetRoleById(roleRequest);
            RoleDTO excpected = new RoleDTO();
            excpected.RoleId = ROLE_ID;
            excpected.Description = ROLE_DESCRIPTION;
            Assert.AreEqual(result.RoleId, excpected.RoleId);
        }

        [TestMethod]
        public void TestGetAllRoles()
        {
            roleRequest.RoleId = ROLE_ID;
            roleRequest.Description = ROLE_DESCRIPTION;
            roleService.AddRole(roleRequest);
            List<RoleDTO> result = roleService.GetAllRoles();
            RoleDTO excpected = new RoleDTO();
            excpected.RoleId = ROLE_ID;
            excpected.Description = ROLE_DESCRIPTION;
            Assert.AreEqual(result[0].RoleId, excpected.RoleId);
        }

        [TestMethod]
        public void TestGetAllActiveRoles()
        {
            roleRequest.RoleId = ROLE_ID;
            roleRequest.Description = ROLE_DESCRIPTION;
            roleService.AddRole(roleRequest);
            List<RoleDTO> result = roleService.GetAllActiveRoles();
            RoleDTO excpected = new RoleDTO();
            excpected.RoleId = ROLE_ID;
            excpected.Description = ROLE_DESCRIPTION;
            Assert.AreEqual(result[0].RoleId, excpected.RoleId);
        }
    }
}
