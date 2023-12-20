using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("get")]
        public async Task<ActionResult<IEnumerable<TimeTable>>> GetTimeTables() {
            return Ok(await _timeTableService.GetTimeTableDetails());
        }

        [HttpPost("add")]
        public async Task<ActionResult<Response>> AddDetails([FromBody] TimeTableDto timeTableDto) {
            return Ok(await _timeTableService.AddTimeTableDetails(timeTableDto));
        }
        
    }
}
