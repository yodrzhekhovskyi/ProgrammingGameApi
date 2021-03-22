using ProgrammingGameApi.Services;
using System;

namespace ProgrammingGameApi.Dtos
{
    public class UserStatsDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int TotalSnippetsForRiddlesSent { get; set; }
        public int TotalCorrectCompilations { get; set; }
        public DateTime TotalTimeSpentOnRiddles { get; set; }
        public int RiddlesSolved { get; set; }
        public SnippetLanguageCode PreferableLanguage { get; set; }
    }
}
