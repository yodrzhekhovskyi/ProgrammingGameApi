using System.Collections.Generic;

namespace ProgrammingGameApi.Services.Helpers.FakeDb.Models
{
    /// <summary>
    /// Test case to check riddle's correctness
    /// </summary>
    public class TestCase
    {
        /// <summary>
        /// List of args which will be passed to code
        /// </summary>
        public IEnumerable<object> Args { get; set; }

        /// <summary>
        /// Expected result
        /// </summary>
        public object Result { get; set; }
    }
}
