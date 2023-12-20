namespace TimeTableProject.Dto
{
    public class Response
    {
        public string Status { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
    }
}
