namespace TimeTableProject.Entities
{
    public class TimeTable
    {
        public int Id { get; set; }
        public string AttendanceType { get; set; }
        public string Batch { get; set; }
        public string ClassTime { get; set; }
        public string ClassMode { get; set; }
        public string ClassRoom { get; set; }
        public string SubjectDuration { get; set; }
        public string SubjectName { get; set; }
        public int Term { get; set; }
        public string TrainerName { get; set; }

        public TimeTable(string attendanceType, string batch, string classTime, string classMode, string classRoom,
            string subjectDuration, string subjectName, int term, string trainerName)
        {
            AttendanceType = attendanceType;
            Batch = batch;
            ClassTime = classTime;
            ClassMode = classMode;
            ClassRoom = classRoom;
            SubjectDuration = subjectDuration;
            SubjectName = subjectName;
            Term = term;
            TrainerName = trainerName;
        }
    }
}
