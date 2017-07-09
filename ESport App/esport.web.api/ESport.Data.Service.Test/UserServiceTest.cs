using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ESport.Data.Commons;

using ESport.Repository.Stub.Test;
using ESport.Data.Entities;

namespace ESport.Data.Service.Test
{
    [TestClass]
    
    public class UserServiceTest
    {
        IUserService userService;
        string USER_ID = "userId";
        UserRequest request;
        IUserRepository userRepository;
        public UserServiceTest()
        {
            userRepository = new StubUserRepository();
            IRoleRepository roleRepository = new StubRoleRepository();
            string ROLE_ID = "admin";
            string ROLE_DESCRIPTION = "Administrador de Sistema";
            Role role = new Role(ROLE_ID, ROLE_DESCRIPTION);
            roleRepository.AddEntity(role);
            IUserManager userManager = new UserManager(userRepository, roleRepository);
            userService = new UserServiceImpl(userManager, new UserDTOBuilder());
            string USER_NAME = "Juan";
            string USER_LASTNAME = "Perez";
            string USER_ADDRESS = "Ejido 1928";
            string USER_EMAIL = "juanperez@gmail.com";
            string USER_PASSWORD = "C45%d.a";
            request = new UserRequest();
            request.UserId = USER_ID;
            request.Address = USER_ADDRESS;
            request.UserLastName = USER_LASTNAME;
            request.UserName = USER_NAME;
            request.EMail = USER_EMAIL;
            request.Password = USER_PASSWORD;
            request.RoleId = ROLE_ID;
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
        public void TestAddUser()
        {
            userService.AddUser(request);
            Assert.AreEqual(userRepository.GetAllActiveUsers()[0].UserId, USER_ID);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddUserValidateUserId()
        {
            request.UserId = null;
            userService.AddUser(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddUserValidateUserName()
        {
            request.UserName = null;
            userService.AddUser(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddUserValidateUserLastName()
        {
            request.UserLastName = null;
            userService.AddUser(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddUserValidateUserAddress()
        {
            request.Address= null;
            userService.AddUser(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddUserValidateUserRoleId()
        {
            request.RoleId = null;
            userService.AddUser(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddUserValidateUserMail()
        {
            request.EMail = null;
            userService.AddUser(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddUserValidateUserMailTwo()
        {
            request.EMail = "testMail";
            userService.AddUser(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestAddUserValidateUserMailThree()
        {
            request.EMail = "testMail@";
            userService.AddUser(request);
        }

        

      

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestEditUser()
        {
            string NEW_NAME = "newName";
            userService.AddUser(request);
            request.UserName = NEW_NAME;
            userService.EditUser(request);
            Assert.AreEqual(userRepository.GetAllActiveUsers()[0].UserName, NEW_NAME);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestEditUserValidateUserId()
        {
            userService.AddUser(request);
            request.UserId = null;
            userService.EditUser(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestEditUserValidateUserName()
        {
            userService.AddUser(request);
            request.UserName = null;
            userService.EditUser(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestEditUserValidateUserLastName()
        {
            userService.AddUser(request);
            request.UserLastName = null;
            userService.EditUser(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestEditUserValidateUserAddress()
        {
            userService.AddUser(request);
            request.Address = null;
            userService.EditUser(request);
        }

        [TestMethod]
        public void TestEditUserValidateUserRoleId()
        {
            userService.AddUser(request);
            request.RoleId = null;
            userService.EditUser(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestEditUserValidateUserMail()
        {
            userService.AddUser(request);
            request.EMail = null;
            userService.EditUser(request);
        }

        [TestMethod]
        public void TestRemoveUser()
        {
            userService.AddUser(request);
            userService.RemoveUser(request);
            Assert.IsTrue(userRepository.GetAllEntities()[0].Eliminated);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestRemoveUserValidateUserId()
        {
            userService.AddUser(request);
            request.UserId = null;
            userService.RemoveUser(request);
        }

        [TestMethod]
        public void TestRemoveUserValidateUserName()
        {
            userService.AddUser(request);
            request.UserName = null;
            userService.RemoveUser(request);
        }

        [TestMethod]
        public void TestRemoveUserValidateUserLastName()
        {
            userService.AddUser(request);
            request.UserLastName = null;
            userService.RemoveUser(request);
        }

        [TestMethod]
        public void TestRemoveUserValidateUserAddress()
        {
            userService.AddUser(request);
            request.Address = null;
            userService.RemoveUser(request);
        }

        [TestMethod]
        public void TestRemoveUserValidateUserRoleId()
        {
            userService.AddUser(request);
            request.RoleId = null;
            userService.RemoveUser(request);
        }

        [TestMethod]
        public void TestRemoveUserValidateUserMail()
        {
            userService.AddUser(request);
            request.EMail = null;
            userService.RemoveUser(request);
        }

        [TestMethod]
        public void TestGetAllUsers()
        {
            userService.AddUser(request);
            List<UserDTO> usersDTOResult = userService.GetAllUsers();
            Assert.AreNotEqual(usersDTOResult.Count, ESportUtils.EMPTY_LIST);
        }

        [TestMethod]
        public void TestGetAllActiveUsers()
        {
            userService.AddUser(request);
            List<UserDTO> usersDTOResult = userService.GetAllActiveUsers();
            Assert.AreNotEqual(usersDTOResult.Count, ESportUtils.EMPTY_LIST);
        }

        [TestMethod]
        public void TestGetAllActiveUsersTwo()
        {
            userService.AddUser(request);
            userService.RemoveUser(request);
            List<UserDTO> usersDTOResult = userService.GetAllActiveUsers();
            Assert.AreEqual(usersDTOResult.Count, ESportUtils.EMPTY_LIST);
        }

        [TestMethod]
        public void TestGetUserById()
        {
            userService.AddUser(request);
            UserDTO userDTOResult = userService.GetUserById(request);
            Assert.IsNotNull(userDTOResult);
        }
        

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestGetUserByIdValidateUserId()
        {
            userService.AddUser(request);
            request.UserId = "  ";
            UserDTO userDTOResult = userService.GetUserById(request);
        }

        [TestMethod]
        public void TestUpdatePassword()
        {
            string NEW_PASSWORD = "newPassword";
            userService.AddUser(request);
            request.NewPassword = NEW_PASSWORD;
            userService.UpdatePassword(request);
            User user = userRepository.GetUserById(request.UserId);
            Assert.AreEqual(NEW_PASSWORD, user.Password);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestUpdatePasswordAndValidateRequestPassword()
        {
            string NEW_PASSWORD = "newPassword";
            userService.AddUser(request);
            request.NewPassword = NEW_PASSWORD;
            request.Password = "  ";
            userService.UpdatePassword(request);
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public void TestUpdatePasswordAndValidateRequestNewPassword()
        {
            userService.AddUser(request);
            userService.UpdatePassword(request);
        }
    }
}
