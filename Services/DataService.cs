public class DataService : IDataService
{
    public List<string> GetStudents()
    {
        return new List<string>
        {
            "Alice",
            "Bob",
            "Charlie"
        };
    }
}
