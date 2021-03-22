using ProgrammingGameApi.Services;

namespace ProgrammingGameApi.Dtos
{
    public class RextesterResponseDto
    {
        public string Warnings { get; set; }

        public string Errors { get; set; }

        public string Result { get; set; }

        public string Stats { get; set; }

        public string Files { get; set; }

        public bool NotLoggedIn { get; set; }
    }
}
