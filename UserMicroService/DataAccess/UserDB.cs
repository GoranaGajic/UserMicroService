using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserMicroService.Models;
using UserMicroService.Util;

namespace UserMicroService.DataAccess
{
    public static class UserDB
    {

        //lista svih usera
        public static List<User> listOfUsers = new List<User>();

        //svi useri
        public static List<User> GetAllUsers()
        {
            return listOfUsers;
        }

        //user po id
        public static User GetUserById (int id)
        {
            foreach (User user in listOfUsers)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }
            //dodavanje novog
            public static User AddNewUser(User user)
            {
                listOfUsers.Add(user);
                return user;
            }

        //vracanje po imenu

        public static List<User> GetUserByName(string Name)
        {
            List<User> userByName = new List<User>();
            foreach (User user in listOfUsers)
            {
                if (user.Name.Equals(Name))
                {

                    userByName.Add(user);
                }
            }

            if (userByName.Count > 0)
            {
                return userByName;
            }
            return null;
        }

            //brisanje korisnika po id
            public static void DeleteUser(int Id)
            {
                User deleteUser = GetUserById(Id);
                listOfUsers.Remove(deleteUser);
            }

        //modifikacija
        public static User CreateNewUser(int id, string name, string email, string adresa, string zipCode, string cityName, string countryName, string phone)
        {
            User user = new User();
            user.Id = id;
            user.Name = name;
            user.Email = email;
            user.Adresa = adresa;
            user.ZipCode = zipCode;
            user.CityName = cityName;
            user.CountryName = countryName;
            user.Phone = phone;

            return user;
        }

        //modifikovanje korisnika
        public static User ModifyUser(int id, string name, string email, string adresa, string zipCode, string cityName, string countryName, string phone)
        {
            User user = CreateNewUser(id, name, email, adresa, zipCode, cityName, countryName, phone);
            DeleteUser(id);
            AddNewUser(user);

            return user;
        }
    }
}
        }
    }

        
    