using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using UserMicroService.DataAccess;
using UserMicroService.Models;

namespace UserMicroService.Controllers
{
    public class UserController : ApiController //metode koje pozivaju druge metode=endpoint
    {
        /// <summary>
        /// Gets single user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Single user</returns>
        /// 
        [Route("api/User/{id}"),HttpGet]//definisemo putanju do kontrolera kad se pokrenu servisi
        //u postmanu dodajemo ovo na http link
        public User GetUserById(int id)
        {
            return UserDB.GetUserById(id);
        }
    }
}