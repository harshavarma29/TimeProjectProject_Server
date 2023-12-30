namespace TimeTableProject.TimeTableGenerator
{
    public class StudentGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Subject { get; set; }
        public int SubjectsCount { get; set; }
        public int[] TeacherId { get; set; }
        public int[] Hours { get; set; }

        public StudentGroup()
        {
            Subject = new string[10];
            Hours = new int[10];
            TeacherId = new int[10];
        }
    }
}
