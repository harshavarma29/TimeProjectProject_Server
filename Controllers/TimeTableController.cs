using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TimeTableProject.Dto;
using TimeTableProject.Entities;
using TimeTableProject.Services;

namespace TimeTableProject.Controllers
{
    [ApiController]
    [Route("[controller]/details")]
    [EnableCors("AllowOrigin")]
    public class TimeTableController: ControllerBase
    {

        private TimeTableService _timeTableService;

        public TimeTableController(TimeTableService timeTableService) {
            _timeTableService = timeTableService;
        }

        [HttpPost("add")]
        public ActionResult<SuccessResponse> AddDetails([FromBody] ScheduleDetails scheduleDetails) {
            return Ok(_timeTableService.AddTimeTableDetails(scheduleDetails));
        }

        [HttpGet("get/all-response-ids")]
        public ActionResult<List<Guid>> GetAllResponses()
        {
            return Ok(_timeTableService.GetAllResponses());
        }

        [HttpGet("get/{referenceId}")]
        public ActionResult<Response> GetTimeTables(Guid referenceId)
        {
            Response response = JsonSerializer.Deserialize<Response>(_timeTableService.GetTimeTableDetails(referenceId));
            
            return Ok(response);
        }

    }
}
