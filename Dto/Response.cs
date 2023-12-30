using TimeTableProject.TimeTableGenerator;

namespace TimeTableProject.Dto
{
    public class Response
    {
        public string Status { get; set; }
        public Guid ReferenceId { get; set; }
        public string SchoolStartTime { get; set; }
        public string ClassDuration { get; set; }
        public string BreakDuration { get; set; }
        public List<string> Teachers { get; set; }
        public List<string> Batches { get; set; }
        public List<Day> Days { get; set; }
        public Chromosome SlotNums { get; set; }
        public Slot[] Slots { get; set; }
    }
}
