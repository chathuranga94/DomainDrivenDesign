using BiBi.DataAccess.Repository;
using BiBi.Domain.Models;
using BiBi.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BiBi.WebAPI.Controllers
{
    [RoutePrefix("user")]
    public class UserController : ApiController
    {
        private static IUserRepository userRepo;
        public UserController()
        {
            userRepo = userRepo ?? new UserRepository();
            // if (userRepo == null) { userRepo = new UserRepository(); }
            // ??   ?   ?.      Ternary Operators C#
            // http://stackoverflow.com/questions/26516825/argument-exception-item-with-same-key-has-already-been-added
            // http://stackoverflow.com/questions/5648060/an-item-with-the-same-key-has-already-been-added
        }


        /// <summary>
        /// GET all users
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpGet]
        public List<User> GetAllUsers()
        {
            List<User> AllUsers = userRepo.GetAll();
            return AllUsers;
        }

        /// <summary>
        /// GET user by ID
        /// </summary>
        /// <param name="id">30</param>
        /// <returns></returns>
        [Route("{id:int}")]
        [HttpGet]
        public User GetUser(int id)
        {
            User NewUser = new User();
            NewUser.UserID = id;
            NewUser.FirstName = "C";
            NewUser.LastName ="D";



            IAccountRepository accountRepo = new AccountRepository();
            Account acc = new Account();
            acc.Balance = 1000;
            acc.AccountID = 120;
            accountRepo.Add(acc);

            accountRepo.GetAll();

            return NewUser;
        }

        [Route("add")]
        [HttpPost]
        public User AddUser([FromBody] User newUser)
        {
            userRepo.Add(newUser);
            return newUser;

            //User NewUser = new User();
            ////NewUser.UserId = 10;
            //NewUser.FirstName = "A";
            //NewUser.LastName = "B";
            //AllUsers.Add(NewUser);

            //JSON POST Example:
            /*  {
                    "UserID": 14,
                    "FirstName": "s",
                    "LastName": "a"
                }
            */

    }

    }
}
