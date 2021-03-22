using ProgrammingGameApi.Services.Helpers.FakeDb.Models;
using System.Collections.Generic;

namespace ProgrammingGameApi.Services.Interfaces
{
    public interface IUsersService
    {
        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns>List of users</returns>
        List<User> GetUsers();

        /// <summary>
        /// Finds and returns user with specified identifier
        /// </summary>
        /// <param name="id">User's identifier</param>
        /// <returns>Specified user</returns>
        User GetUserById(int id);

        /// <summary>
        /// Updates user email
        /// </summary>
        /// <param name="id">User's identifier</param>
        /// <param name="newEmail">New user's email</param>
        /// <returns>Changed user</returns>
        User UpdateUserEmail(int id, string newEmail);
    }
}
