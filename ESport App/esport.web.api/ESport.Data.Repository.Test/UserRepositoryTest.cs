using ESport.Data.Entities;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ESport.Data.Repository.Test
{

    [TestClass]
    
    public class UserRepositoryTest
    {
        UserRepository userRepository;
        User userTest;
        RoleRepository roleRepository;
        public UserRepositoryTest()
        {
            CleanRepositoryHelperTest.CleanDB();
            userRepository = new UserRepository();
            roleRepository = new RoleRepository();
            userTest = new User("00000", "Maria", "Sapelli", "few3",
            "acevedo1927", "titisapelli@hotmail.com", "asd");
            
        }
       

        [TestMethod]
        public void TestRepositoryAddUser()
        {
            userRepository.AddEntity(userTest);
            Assert.IsTrue(userTest.Equals(userRepository.GetUserById(userTest.UserId)));
        }

        [TestMethod]
        public void TestRepositoryAddUserAndValidateRole()
        {
            Role role = new Role("admin", "Administrador del sistema");
            roleRepository.AddEntity(role);
            userTest.Roles.Add(role);
            userRepository.AddEntity(userTest);
            Role expectedRole = userRepository.GetUserById(userTest.UserId).Roles.Where(r => r.RoleId == role.RoleId).First();
            Assert.AreEqual(role,expectedRole);
        }

        [TestMethod]
        public void TestRepositoryUpdateUserAndValidateRole()
        {
            Role role = new Role("admin", "Administrador del sistema");
            roleRepository.AddEntity(role);
            userRepository.AddEntity(userTest);
            userRepository.AddRoleInUser(userTest, role);
            User userResult = userRepository.GetUserById(userTest.UserId);
            Role expectedRole =userResult.Roles.Where(r => r.RoleId == role.RoleId).First();
            Assert.AreEqual(role,expectedRole);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryAddUserExcpetion()
        {
            userRepository.AddEntity(userTest);
            User user2 = new User("00000", "Maria", "Sapelli", "few3",
            "acevedo1927", "titisapelli@hotmail.com", "asd");
            userRepository.AddEntity(user2);
        }

        [TestMethod]
        public void TestRepositoryAddMultipleUsers()
        {
            User user = new User("33333", "Ana", "Ferres", "e23e3e",
               "Ejido 1932", "titisapelliferres@gmail.com", "3rwer4");
            userRepository.AddEntity(userTest);
            userRepository.AddEntity(user);

            List<User> expectedUsers = new List<User> { userTest, user };
            List<User> list = userRepository.GetAllEntities();
            Assert.IsTrue(list.Contains(userTest) && list.Contains(user));
        }
        [TestMethod]
        public void TestRepositoryGetAllActiveUsers()
        {
            userRepository.AddEntity(userTest);
            List<User> expectedUsers = new List<User> { userTest };
            Assert.IsTrue(userRepository.GetAllActiveUsers().Contains(userTest));
        }

        [TestMethod]
        public void TestRepositoryGetAllActiveUsersWhenNoUsersAreStored()
        {
            List<User> expectedUsers = userRepository.GetAllActiveUsers();
            Assert.AreEqual(0, expectedUsers.Count());
        }

        [TestMethod]
        public void TestRepositoryGetAllEntities()
        {
            userRepository.AddEntity(userTest);
            List<User> expectedUsers = new List<User> { userTest };
            Assert.IsTrue(userRepository.GetAllEntities().Contains(userTest));
        }

        [TestMethod]
        public void TestRepositoryGetAllEntitiesWhenNoUsersAreStored()
        {
            List<User> expectedUsers = userRepository.GetAllEntities();
            Assert.AreEqual(0, expectedUsers.Count());
        }

        [TestMethod]
        public void TestRepositoryGetUserById()
        {
            userRepository.AddEntity(userTest);
            User t = userRepository.GetUserById(userTest.UserId);
            Assert.IsTrue(userTest.Equals(t));
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryGetUnexistingUserById()
        {
            string UserId = "8888";
            User t = userRepository.GetUserById(UserId);
        }

        [TestMethod]
        public void TestRepositoryUpdateUser()
        {
            string NEW_NAME = "updateName";
            userRepository.AddEntity(userTest);
            userTest.UserName = NEW_NAME;
            userRepository.UpdateEntity(userTest);
            User obtainedUser = userRepository.GetUserById(userTest.UserId);
            Assert.IsTrue(NEW_NAME.Equals(obtainedUser.UserName));
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryUpdateUnexistingUser()
        {
            userRepository.UpdateEntity(userTest);
        }

        [TestMethod]
        public void TestRepositoryRemoveEntity()
        {
            userRepository.AddEntity(userTest);
            userRepository.RemoveEntity(userTest);
            Assert.AreEqual(0, userRepository.GetAllActiveUsers().Count());
        }

        [TestMethod]
        [ExpectedException(typeof(RepositoryException))]
        public void TestRepositoryRemoveUnexistingEntity()
        {
            userRepository.RemoveEntity(userTest);
        }

       
    }
}