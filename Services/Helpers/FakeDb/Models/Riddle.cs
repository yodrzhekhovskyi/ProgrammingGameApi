using System.Collections.Generic;

namespace ProgrammingGameApi.Services.Helpers.FakeDb.Models
{
    /// <summary>
    /// Riddle model
    /// </summary>
    public class Riddle
    {
        /// <summary>
        /// Riddle identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// List of test cases
        /// </summary>
        public List<TestCase> TestCases { get; set; }
    }
}
