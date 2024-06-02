public class Task
{
    public int id { get; set; }
    public int personId { get; set; }
    public string name { get; set; } 
    public string description { get; set; }
    public DateTime date { get; set; }
    public virtual Person idPersonNavigator { get; set; }
}

