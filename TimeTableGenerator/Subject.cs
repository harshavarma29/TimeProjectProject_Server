namespace TimeTableProject.TimeTableGenerator
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Teacher[] Teacher { get; set; }
        public int TeachersCount { get; set; }
        public Subject()
        {
            Teacher = new Teacher[20];
        }
    }
}
