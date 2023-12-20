using Microsoft.EntityFrameworkCore;
using TimeTableProject.Data;
using TimeTableProject.Dto;
using TimeTableProject.Entities;

namespace TimeTableProject.Services
{
    public class TimeTableService
    {
        private DataContext _dataContext;
        public TimeTableService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<TimeTable>> GetTimeTableDetails() {
            return await _dataContext.TimeTable.ToListAsync();
        }

        public async Task<Response> AddTimeTableDetails(TimeTableDto timeTableDto) {
            TimeTable timeTable = new TimeTable(timeTableDto.AttendanceType, timeTableDto.Batch, 
                timeTableDto.ClassStartTime+" - "+timeTableDto.ClassEndTime, timeTableDto.ClassMode, 
                timeTableDto.ClassRoom, timeTableDto.SubjectDurationFrom+" - "+timeTableDto.SubjectDurationTo, 
                timeTableDto.SubjectName, timeTableDto.Term, timeTableDto.TrainerName);
            await _dataContext.TimeTable.AddAsync(timeTable);
            _dataContext.SaveChanges();
            Response response = new Response();
            response.Status = "Success";
            response.Messages.Add("Details Inserted Successfully");
            return response;
        }
    }
}
