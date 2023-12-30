using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TimeTableProject.Data;
using TimeTableProject.Dto;
using TimeTableProject.Entities;
using TimeTableProject.TimeTableGenerator;

namespace TimeTableProject.Services
{
    public class TimeTableService
    {
        private DataContext _dataContext;
        public TimeTableService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public string GetTimeTableDetails(Guid referenceId) {
            return _dataContext
                .Responses.Where(responses => responses.ReferenceId == referenceId)
                .FirstOrDefault()
                .Response;
        }

        public List<Guid> GetAllResponses()
        {
            List<Guid> referenceIds = _dataContext.Responses.ToList().Select(responses => responses.ReferenceId).ToList();
            return referenceIds;
        }

        public SuccessResponse AddTimeTableDetails(ScheduleDetails scheduleDetails)
        {
            Guid referenceId = Guid.NewGuid();
            new InputData(referenceId, _dataContext).InitializeData(scheduleDetails);
            new SchedulerMain();

            Response response = new Response();
            response.Status = "Success";
            response.ReferenceId = referenceId;
            response.SchoolStartTime = scheduleDetails.SchoolStartTime;
            response.ClassDuration = scheduleDetails.ClassDuration;
            response.BreakDuration = scheduleDetails.BreakDuration;
            response.Teachers = scheduleDetails.Teachers.Select(teacher => teacher.Name).ToList();
            response.Batches = scheduleDetails.Batches.Select(batch => batch.ClassName).ToList();
            response.Days = scheduleDetails.Days.Where(day => day.selected == true).ToList();
            response.SlotNums = SchedulerMain.FinalSon;
            response.Slots = TimeTableGenerator.TimeTable.Slot;

            Responses responses = new Responses();
            responses.ReferenceId = referenceId;
            responses.Response = JsonSerializer.Serialize(response);
            _dataContext.Responses.Add(responses);

            _dataContext.SaveChanges();

            SuccessResponse successResponse = new SuccessResponse("Generated Successfully");
            return successResponse;
        }
    }
}
