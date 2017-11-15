using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMicroService.DataAccess;
using UserMicroService.Models;
using UserMicroService.Util;

namespace UserMicroService.Tests
{
    public class UserTest
    {
    
        public void ClearUsers() {
            UserDB.listOfUsers.Clear();
        }
        [Test]
        public void CreateUserSuccess()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Milica"
            };

            UserDB.AddNewUser(testUser);
            Assert.AreEqual(1, UserDB.listOfUsers.Count);
        }

        [Test]
        public void RemoveUserSuccess()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Milica"
            };

            UserDB.AddNewUser(testUser);
            UserDB.DeleteUser(testUser.Id);
            Assert.AreEqual(0, UserDB.listOfUsers.Count);

        }

        [Test]
        public void RemoveUserFail()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Milica"
            };

            UserDB.AddNewUser(testUser);
            UserDB.DeleteUser(3);
            Assert.AreEqual(1, UserDB.listOfUsers.Count);

        }

        [Test]

        public void GetAllUsersSuccess()
        {
            ClearUsers();

            User testUser1 = new User
            {
                Id = 1,
                Name = "Tijana"
            };

            User testUser2 = new User
            {
                Id = 2,
                Name = "Milan"
            };

            User testUser3 = new User
            {
                Id = 3,
                Name = "Nevena"
            };

            User testUser4 = new User
            {
                Id = 4,
                Name = "Marko"
            };

            UserDB.AddNewUser(testUser1);
            UserDB.AddNewUser(testUser2);
            UserDB.AddNewUser(testUser3);
            UserDB.AddNewUser(testUser4);
            Assert.AreEqual(4, UserDB.GetAllUsers().Count);
        }
        [Test]
        public void GetUserByName()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Tijana"
            };
            UserDB.AddNewUser(testUser);
            Assert.AreEqual(testUser, UserDB.GetUserByName("Tijana" ));

        }



        [Test]

        public void GetUserByIdSuccess()
        {
            ClearUsers();
            User testUser = new User
            {
                Id=1,
                Name="Tijana"
            };
            UserDB.AddNewUser(testUser);
            Assert.AreEqual(testUser, UserDB.GetUserById(1));
        }

    }
}

