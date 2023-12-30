namespace TimeTableProject.TimeTableGenerator
{
    public class Slot
    {
        public StudentGroup StudentGroup;
        public int TeacherId { get; set; }
        public string Subject {  get; set; }

        public Slot() { }

        public Slot(StudentGroup studentGroup, int teacherId, string subject) {
            StudentGroup = studentGroup;
            TeacherId = teacherId;
            Subject = subject;
        }
    }
}
