namespace ProgrammingGameApi.Services.Helpers.FakeDb.Models
{
    /// <summary>
    /// User models
    /// </summary>
    public class User
    {
        /// <summary>
        /// User identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; set; }
    }
}
