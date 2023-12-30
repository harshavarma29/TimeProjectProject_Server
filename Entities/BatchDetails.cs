namespace TimeTableProject.Entities
{
    public class BatchDetails
    {
        public int Id { get; set; }
        public Guid ReferenceId { get; set; }
        public string ClassName { get; set; }
        public string SubjectName { get; set; }
        public int Hours { get; set; }
    }
}
