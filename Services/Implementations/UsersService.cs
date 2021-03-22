using ProgrammingGameApi.Services.Helpers.FakeDb.Models;
using ProgrammingGameApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgrammingGameApi.Services.Implementations
{
    /// <summary>
    /// Users queries and management
    /// </summary>
    public class UsersService : BaseService, IUsersService
    {
        /// <summary>
        /// <inheritdoc cref="IUsersService.GetUsers"/>
        /// </summary>
        public List<User> GetUsers()
        {
            return _db.Users;
        }

        /// <summary>
        /// <inheritdoc cref="IUsersService.GetUserById(int)"/>
        /// </summary>
        public User GetUserById(int id)
        {
            return _db.Users.SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// <inheritdoc cref="IUsersService.UpdateUserEmail(int, string)"/>
        /// </summary>
        public User UpdateUserEmail(int id, string newEmail)
        {
            var user = _db.Users.SingleOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new ArgumentException("A user with specified id not found");
            }

            if (user.Email == newEmail)
            {
                throw new ArgumentException("New email should be different from the old one");
            }

            user.Email = newEmail;

            return user;
        }
    }
}
