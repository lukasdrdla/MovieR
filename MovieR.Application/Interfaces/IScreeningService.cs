using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieR.Application.Dtos.Screening;

namespace MovieR.Application.Interfaces
{
    public interface IScreeningService
    {
        Task<IEnumerable<ScreeningDto>> GetAllScreenings();
        Task<ScreeningDto> GetScreeningById(Guid id);
        Task<ScreeningDto> CreateScreening(CreateScreeningDto screeningDto);
        Task<ScreeningDto> UpdateScreening(Guid id, UpdateScreeningDto screeningDto);
        Task<bool> DeleteScreening(Guid id);


        Task<IEnumerable<ScreeningDto>> GetAvailableScreenings(Guid movieId, DateTime date);
        Task<IEnumerable<ScreeningDto>> GetTodayScreenings();
        Task<IEnumerable<ScreeningDto>> GetScreeningsByMovieId(Guid movieId);
        Task<IEnumerable<ScreeningDto>> GetUpcomingScreenings(int? daysAhead = null, DateTime? fromDay = null, DateTime? toDay = null);
        Task<IEnumerable<ScreeningDto>> SearchScreenings(string search);


        
    }
}