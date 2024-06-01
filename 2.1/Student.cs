namespace _2._1;
public class Student
{
    public string surname;
    public DateTime birthday;
    public int group;
    public int[] assessments = new int[5];
    
    public void display()
    {
        Console.WriteLine($"ФИО: {surname}\nДата рождения: {birthday}\nНомер группы: {group}\nОценки: {string.Join(", ", assessments)}\n------------");
    }
}