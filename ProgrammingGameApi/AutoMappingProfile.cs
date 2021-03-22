using AutoMapper;
using ProgrammingGameApi.Dtos;
using ProgrammingGameApi.Services.HelperClasses;
using ProgrammingGameApi.Services.Helpers.FakeDb.Models;

namespace ProgrammingGameApi
{
    /// <summary>
    /// Auto mapping profile
    /// </summary>
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            // Riddles
            CreateMap<Riddle, RiddleDto>();
            CreateMap<TestCase, TestCaseDto>();

            // Users
            CreateMap<User, UserDto>();

            // Programming language
            CreateMap<ProgrammingLanguage, ProgrammingLanguageDto>();

            // Rextester response
            CreateMap<RextesterResponse, RextesterResponseDto>();

            // Stats
            CreateMap<UserStats, UserStatsDto>();
        }
    }
}
