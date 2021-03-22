using ProgrammingGameApi.Services.Helpers.FakeDb.Models;
using ProgrammingGameApi.Services.PayloadClasses;

namespace ProgrammingGameApi.Services.Interfaces
{
    /// <summary>
    /// Authentication queries and management
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Logins user
        /// </summary>
        /// <param name="userPayload">User's data object</param>
        /// <returns>Logged user</returns>
        User Login(UserPayload userPayload);

        /// <summary>
        /// Registers user
        /// </summary>
        /// <param name="userPayload">User's data object</param>
        /// <returns>Registered user</returns>
        User Register(UserPayload userPayload);

        /// <summary>
        /// Logouts current user
        /// </summary>
        void Logout();
    }
}
