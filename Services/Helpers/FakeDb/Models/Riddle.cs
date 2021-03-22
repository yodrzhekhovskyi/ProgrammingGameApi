using System.Collections.Generic;

namespace ProgrammingGameApi.Services.Helpers.FakeDb.Models
{
    /// <summary>
    /// Riddle model
    /// </summary>
    public class Riddle
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<TestCase> TestCases { get; set; }
    }
}
