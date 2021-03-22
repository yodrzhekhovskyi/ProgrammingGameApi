using ProgrammingGameApi.Services.Helpers;
using ProgrammingGameApi.Services.Helpers.FakeDb.Models;
using System.Net.Http;

namespace ProgrammingGameApi.Services.Implementations
{
    /// <summary>
    /// Base class for services.
    /// </summary>
    public class BaseService
    {
        /// <summary>
        /// Static instance of fake in-memory db
        /// </summary>
        public readonly static Db _db = new Db();

        /// <summary>
        /// Static intance of http client. 
        /// </summary>
        public static HttpClient Client = new HttpClient();

        /// <summary>
        /// User logged in
        /// </summary>
        public static User LoggedUser;
    }
}
