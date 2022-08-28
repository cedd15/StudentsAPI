namespace StudentAPI.ViewModels
{
    public class StudentsWithTheirCourses
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public IEnumerable<string> Courses { get; set; }
    }
}
