namespace TimeTableProject.Dto
{
    public class ScheduleDetails
    {
        public string SchoolStartTime { get; set; }
        public int ClassesPerDay { get; set; }
        public string ClassDuration { get; set; }
        public string BreakDuration { get; set; }
        public List<Day> Days { get; set; }
        public List<Teachers> Teachers { get; set; }
        public List<Batches> Batches { get; set; }
    }
}
