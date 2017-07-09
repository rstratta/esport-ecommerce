using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESport.Data.Entities;
using System.Linq;


namespace ESport.Data.Repository.Test
{
    [TestClass]
    
    public class RoleRepositoryTest
    {
        RoleRepository roleRepository;
        Role roleTest;
        public RoleRepositoryTest()
        {
            CleanRepositoryHelperTest.CleanDB();
            roleRepository = new RoleRepository();
            roleTest = new Role("admin", "Administrador de sistema");
            
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
        public void TestRepositoryAddRole()
        {
            roleRepository.AddEntity(roleTest);
            Assert.IsTrue(roleTest.Equals(roleRepository.GetRoleById(roleTest.RoleId)));
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryAddRoleExcpetion()
        {
            roleRepository.AddEntity(roleTest);
            Role role = new Role(roleTest.RoleId, roleTest.Description);
            roleRepository.AddEntity(role);
        }

        [TestMethod]
        public void TestRepositoryAddMultipleRoles()
        {
            Role role = new Role("client", "Cliente");
            roleRepository.AddEntity(roleTest);
            roleRepository.AddEntity(role);
            List<Role> expectedRoles = new List<Role> { roleTest, role };
            List<Role> result = roleRepository.GetAllEntities();
            Assert.IsTrue(result.Contains(roleTest) && result.Contains(role));
        }
        [TestMethod]
        public void TestRepositoryGetAllActiveRoles()
        {
            roleRepository.AddEntity(roleTest);
            List<Role> expectedRoles = new List<Role> { roleTest};
            Assert.IsTrue(roleRepository.GetAllActiveRoles().Contains(roleTest));
        }

        [TestMethod]
        public void TestRepositoryGetAllActiveRolesWhenNoRolesAreStored()
        {
            List<Role> expectedRoles = roleRepository.GetAllActiveRoles();
            Assert.AreEqual(0, expectedRoles.Count);
        }

        [TestMethod]
        public void TestRepositoryGetAllRoles()
        {
            roleRepository.AddEntity(roleTest);
            List<Role> expectedRoles = new List<Role> { roleTest };
            Assert.IsTrue(roleRepository.GetAllEntities().Contains(roleTest));
        }

        [TestMethod]
        public void TestRepositoryGetAllEntitiesWhenNoRoleAreStored()
        {
            List<Role> expectedRoles = roleRepository.GetAllEntities();
            Assert.AreEqual(0, expectedRoles.Count());
        }

        [TestMethod]
        public void TestRepositoryGetRoleById()
        {
            roleRepository.AddEntity(roleTest);
            Role roleResult = roleRepository.GetRoleById(roleTest.RoleId);
            Assert.AreEqual(roleResult, roleTest);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryGetUnexistingRoleById()
        {
            roleRepository.GetRoleById(roleTest.RoleId);
        }

        [TestMethod]
        public void TestRepositoryUpdateRole()
        {
            string NEW_DESCRIPTION = "testDescription";
            roleRepository.AddEntity(roleTest);
            roleTest.Description = NEW_DESCRIPTION;
            roleRepository.UpdateEntity(roleTest);
            Role roleResult = roleRepository.GetRoleById(roleTest.RoleId);
            Assert.AreEqual(NEW_DESCRIPTION, roleResult.Description);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryUpdateUnexistingRole()
        {
            roleRepository.UpdateEntity(roleTest);
        }

        [TestMethod]
        public void TestRepositoryRemoveRole()
        {
            roleRepository.AddEntity(roleTest);
            roleRepository.RemoveEntity(roleTest);
            Assert.AreEqual(0, roleRepository.GetAllActiveRoles().Count());
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryRemoveUnexistingRole()
        {
            roleRepository.RemoveEntity(roleTest);
        }
    }
}