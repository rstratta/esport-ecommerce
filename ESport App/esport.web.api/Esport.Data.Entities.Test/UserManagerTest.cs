using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESport.Data.Commons;

using System.Collections.Generic;
using System.Linq;
using ESport.Repository.Stub.Test;
using ESport.Data.Entities;

namespace Esport.Data.Entities.Test
{

    [TestClass]
    
    public class UserManagerTest
    {
        UserRequest userRequest;
        IUserManager userManager;
        IUserRepository userRepository;
        string USER_ID = "123";
        string USER_NAME = "Juan";
        string USER_LASTNAME = "Perez";
        string USER_ADDRESS = "Ejido 1928";
        string USER_EMAIL = "juanperez@gmail.com";
        string USER_PASSWORD = "C45%d.a";
        string USER_PHONE = "099987456";
        bool USER_ELIMINATED = false;
        IRoleRepository roleRepository;
        string ROLE_ID = "admin";
        string ROLE_DESCRIPTION = "Administrador de Sistema";

        public UserManagerTest()
        {
            userRequest = new UserRequest();
            userRequest.Address = USER_ADDRESS;
            userRequest.UserId = USER_ID;
            userRequest.UserLastName = USER_LASTNAME;
            userRequest.UserName = USER_NAME;
            userRequest.Eliminated = USER_ELIMINATED;
            userRequest.EMail = USER_EMAIL;
            userRequest.Password = USER_PASSWORD;
            userRequest.RoleId = ROLE_ID;
            userRequest.Phone = USER_PHONE;
            roleRepository = new StubRoleRepository();
            Role role = new Role(ROLE_ID, ROLE_DESCRIPTION);
            roleRepository.AddEntity(role);
            userRepository = new StubUserRepository();
            userManager = new UserManager(userRepository, roleRepository);
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
        public void TestAddUser()
        {
            userManager.AddUser(userRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestAddUserRepeat()
        {
            userManager.AddUser(userRequest);
            userManager.AddUser(userRequest);
        }

        [TestMethod]
        public void TestEditUser()
        {
            userManager.AddUser(userRequest);
            string NEW_PASSWORD = "siduiuf8.2";
            userRequest.NewPassword = NEW_PASSWORD;
            userManager.UpdatePassword(userRequest);
            User userResult = userRepository.GetUserById(USER_ID);
            Assert.AreEqual(NEW_PASSWORD, userResult.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestEditUserNotExist()
        {
            userManager.EditUser(userRequest);
        }

        [TestMethod]
        public void TestRemoveUser()
        {
            userManager.AddUser(userRequest);
            userManager.RemoveUser(userRequest);
            Assert.AreNotEqual(ESportUtils.EMPTY_LIST, userRepository.GetAllEntities().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestRemoveUserFail()
        {
            userManager.RemoveUser(userRequest);
        }

        [TestMethod]
        public void TestGetAllUser()
        {
            userManager.AddUser(userRequest);
            Assert.AreNotEqual(ESportUtils.EMPTY_LIST, userManager.GetAllUsers().Count);
        }

        [TestMethod]
        public void TestGetAllActiveUsers()
        {
            userManager.AddUser(userRequest);
            userManager.RemoveUser(userRequest);
            Assert.AreEqual(ESportUtils.EMPTY_LIST, userManager.GetAllActiveUsers().Count);
        }

        [TestMethod]
        public void TestGetUserById()
        {
            userManager.AddUser(userRequest);
            User userResult = userManager.GetUserById(USER_ID);
            Assert.AreEqual(userResult.UserId, USER_ID);
        }

        [TestMethod]
        public void TestAssignRole()
        {
            userManager.AddUser(userRequest);
            string OTHER_ROLE_ID = "other";
            string OTHER_ROLE_DESC = "otherDesc";
            Role role = new Role(OTHER_ROLE_ID, OTHER_ROLE_DESC);
            userRequest.RoleId = OTHER_ROLE_ID;
            roleRepository.AddEntity(role);
            userManager.AssignRole(userRequest);
            User userResult = userManager.GetUserById(USER_ID);
            Role expectedUserRole = ((HashSet<Role>)userResult.Roles).Where(r => r.RoleId == role.RoleId).First();
            Role roleFromRepository = roleRepository.GetRoleById(OTHER_ROLE_ID);
            Assert.AreEqual(expectedUserRole,roleFromRepository );
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestAssignRoleException()
        {
            userManager.AddUser(userRequest);
            userManager.AssignRole(userRequest);
            userManager.AssignRole(userRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestAssignRoleExceptionTwo()
        {
            string OTHER_USER_ID = "other";
            userManager.AddUser(userRequest);
            userRequest.UserId = OTHER_USER_ID;
            userManager.AssignRole(userRequest);
        }

        [TestMethod]
        [ExpectedException(typeof(OperationException))]
        public void TestAssignRoleExceptionThree()
        {
            string OTHER_ROLE = "operator";
            userRequest.RoleId = OTHER_ROLE;
            userManager.AddUser(userRequest);
            userManager.AssignRole(userRequest);
        }
    }
}