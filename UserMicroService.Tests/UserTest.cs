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
        public 

    }
}

