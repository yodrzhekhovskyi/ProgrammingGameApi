namespace ProgrammingGameApi.Dtos
{
    /// <summary>
    /// User
    /// </summary>
    public class UserDto
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
    }
}
