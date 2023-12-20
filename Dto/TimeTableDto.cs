namespace TimeTableProject.Dto
{
    public class TimeTableDto
    {
        public string AttendanceType { get; set; }
        public string Batch { get; set; }
        public string ClassStartTime { get; set; }
        public string ClassEndTime { get; set; }
        public string ClassMode { get; set; }
        public string ClassRoom { get; set; }
        public string SubjectDurationFrom { get; set; }
        public string SubjectDurationTo { get; set; }
        public string SubjectName { get; set; }
        public int Term { get; set; }
        public string TrainerName { get; set; }
    }
}
