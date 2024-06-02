public class Person
{
    public int id { get; set; }
    public string login { get; set; }
    public string password { get; set; }
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}

