using TimeTableProject.Dto;

namespace TimeTableProject.Entities
{
    public class TimeDetails
    {
        public int Id { get; set; }
        public Guid ReferenceId { get; set; }
        public string SchoolStartTime { get; set; }
        public int ClassesPerDay { get; set; }
        public string ClassDuration { get; set; }
        public string BreakDuration { get; set; }
        public string Days { get; set; }
    }
}
