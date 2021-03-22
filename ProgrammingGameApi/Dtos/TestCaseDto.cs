using System.Collections.Generic;

namespace ProgrammingGameApi.Dtos
{
    public class TestCaseDto
    {
        public IEnumerable<object> Args { get; set; }
        public object Result { get; set; }
    }
}
