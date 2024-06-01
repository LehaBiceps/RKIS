namespace _2._1;

public class Train
{
    public string destination;
    public string number;
    public DateTime time;
    
    public void display()
    {
        Console.WriteLine($"Поезд №: {number}\nПункт назначения: {destination}\nВремя отправления: {time}\n------------");
    }
}