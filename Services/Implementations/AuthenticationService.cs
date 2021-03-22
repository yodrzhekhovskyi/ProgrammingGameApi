using ProgrammingGameApi.Services.Helpers.FakeDb.Models;
using ProgrammingGameApi.Services.Interfaces;
using ProgrammingGameApi.Services.PayloadClasses;
using System;
using System.Linq;

namespace ProgrammingGameApi.Services.Implementations
{
    /// <summary>
    /// Authentication queries and management
    /// </summary>
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        /// <summary>
        /// <inheritdoc cref="IAuthenticationService.Login(UserPayload)"/>
        /// </summary>
        public User Login(UserPayload userPayload)
        {
            var user = _db.Users.SingleOrDefault(x => x.UserName == userPayload.UserName && x.Password == userPayload.Password);
            LoggedUser = user ?? throw new Exception("A user with specified username doesn't exist or password is incorrect");

            return user;
        }

        /// <summary>
        /// <inheritdoc cref="IAuthenticationService.Register(UserPayload)"/>
        /// </summary>
        public User Register(UserPayload userPayload)
        {
            var usersWithSameUsername = _db.Users.Where(x => x.UserName == userPayload.UserName).Count();

            if (usersWithSameUsername > 0)
            {
                throw new ArgumentException("A user with same username already exists");
            }

            if (userPayload.Password != userPayload.ConfirmPassword)
            {
                throw new ArgumentException("Passwords missmatch");
            }

            var lastId = _db.Users.Select(x => x.Id).LastOrDefault();

            var user = new User
            {
                Id = lastId + 1,
                Password = userPayload.Password,
                UserName = userPayload.UserName,
                Email = userPayload.Email
            };

            _db.Users.Add(user);
            _db.UsersStats.Add(new UserStats { UserId = user.Id, UserName = user.UserName });

            LoggedUser = user;

            return user;
        }

        /// <summary>
        /// <inheritdoc cref="IAuthenticationService.Logout"/>
        /// </summary>
        public void Logout()
        {
            LoggedUser = null;
        }
    }
}
