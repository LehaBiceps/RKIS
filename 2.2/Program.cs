namespace _2._2;
//Создайте список с 10-ю именами. Выведите из этого списка имена начинающиеся на А;
class Program
{
    static void Main(string[] args)
    {
        List<string> name = new List<string>() //создаём список и инициализируем его 10-ю именами
        {
            "Alexey",
            "Ivan",
            "Aleksander",
            "Oleg",
            "Semyon",
            "Olga",
            "Andrey",
            "Islomsho",
            "Rustam",
            "Stas"
        };
        
        foreach (var people in name)//перебираем элементы списка
        {
            if (people.StartsWith("A"))//если элемент списка начинается с буквы A, то
            {
                Console.WriteLine(people);//выводим элементы списка
            }
        }
    }
}














namespace _2._2;
//Создайте класс User с свойствами Login и Password.
//Создайте список объектов User из 5 элементов. Выведите из этого списка пользователя с определенными логином и паролем;
class Program
{
    public class User //создаём класс с именем User 
    {
        public string password;//поле класса
        public string name;//поле класса
    }

    static void displayName(int i, string name)//создаём статичную, ничего не возвращающую функцию,
                                               //передаём число и строку
    {
        Console.WriteLine($"{i}: {name}");//вывод имени с его номером 
    }
    
    static void Main(string[] args)
    {
        List<User> users = new List<User>();//создаём список типа User
        User tom = new User();//создаём объект класса
        tom.name = "Tom";//устанавливаем значения полям класса для объекта tom
        tom.password = "qwerty123";
        users.Add(tom);//добавляем объект tom в список users
        User mark = new User();
        mark.name = "Mark";
        mark.password = "321ytrewq";
        users.Add(mark);
        
        Console.WriteLine("Выберите пользователя: ");//вывод текста
            
        for (int i = 0; i < users.Count; ++i)//цикл, который работает до тех пор, пока не переберёт все элементы списка users
        {
            displayName(i, users[i].name);//вызываем функцию и передаём в неё значения счётчика (i) и имя пользователя (name)
        }
        
        int choise = int.Parse(Console.ReadLine());//считываем данные введённые пользователем(индекс для users)
        Console.WriteLine($"\nВыбран {users[choise].name}");//вывод выбранного пользователя, путём выбора его из списка users(по индексу),
                                                            //который хранит в себе объекты tom и mark
        Console.WriteLine("Введите пароль: ");//вывод текста
        string passsword = Console.ReadLine();//считываем данные введённые пользователем

        if (passsword == users[choise].password)//условие
        {
            Console.WriteLine("Пользователь найден!");//вывод текста
        }
        else
        {
            Console.WriteLine("Неверный пароль!");//вывод текста
        }
    }
}














namespace _2._2;
// Создайте класс Task описывающий занятие, с свойствами: DateStart, DateFinish, Description.
// Создайте список объектов Task из 5 элементов. Выведите информацию о занятии заканчивающемся позже всех,
// если таких занятий несколько, выведите первое подходящее под условие;
class Program
{
    public class Task//создаём класс с именем Task
    {
        public DateTime dateStart;//поле класса
        public DateTime dateFinish;//поле класса
        public string description;//поле класса
    }
    
    static void Main(string[] args)
    {
        List<Task> tasks = new List<Task>();//создаём список типа Task

        Task rkis = new Task();//создаём объект класса
        rkis.dateStart = new DateTime(2024, 12, 15, 12, 30, 00);//устанавливаем значения полям класса для объекта rkis
        rkis.dateFinish = new DateTime(2024, 12, 15, 13, 10, 00);
        rkis.description = "Разработка кода информационных систем";
        tasks.Add(rkis);
        
        Task opbd = new Task();
        opbd.dateStart = new DateTime(2024, 12, 15, 09, 15, 00);
        opbd.dateFinish = new DateTime(2024, 12, 15, 10, 00, 00);
        opbd.description = "Основы проектирования баз данных";
        tasks.Add(opbd);
        
        Task oaip = new Task();
        oaip.dateStart = new DateTime(2024, 12, 15, 14, 45, 00);
        oaip.dateFinish = new DateTime(2024, 12, 15, 15, 20, 00);
        oaip.description = "Основы алгоритмизации и программированние";
        tasks.Add(oaip);
        
        Task pidic = new Task();
        pidic.dateStart = new DateTime(2024, 12, 15, 09, 15, 00);
        pidic.dateFinish = new DateTime(2024, 12, 15, 10, 00, 00);
        pidic.description = "Проектирование и дизайн информационных систем";
        tasks.Add(pidic);
        
        Task osis = new Task();
        osis.dateStart = new DateTime(2024, 12, 15, 23, 10, 00);
        osis.dateFinish = new DateTime(2024, 12, 15, 23, 50, 00);
        osis.description = "Мяу";
        tasks.Add(osis);

        Task latest = tasks.OrderByDescending(t => t.dateFinish).First();//сортируем поле dateFinish

        Console.WriteLine($"\nДата начала: {latest.dateStart}");//вывод даты начала
        Console.WriteLine($"Дата окончания: {latest.dateFinish}");//вывод даты окончания
        Console.WriteLine($"Описание: {latest.description}");//вывод описания
    }
}














namespace _2._2;
// Дана целочисленная последовательность, содержащая как положительные, так и отрицательные числа.
// Вывести ее первый положительный элемент и последний отрицательный элемент;
class Program
{
    static void Main(string[] args)
    {
        int[] nums = { -5, 21, 63, -32, 54, -34, 324, -1313, 4, -1, 43 }; //создаём массив и инициализируем его положительными
                                                                          //и отрицательными числами
        var positive = nums.First(i => i > 0);//возвращает первый элемент массива, который соответствует условию:
                                                   //число должно быть больше 0.
        Console.WriteLine(positive);//вывод положительного числа
        var negative = nums.Last(i => i < 0);//возвращает последний элемент массива, который соответствует условию:
                                                  //число должно быть меньше 0.
        Console.WriteLine(negative);//вывод отрицательного числа
    }
}














namespace _2._2;
// Дан символ С и строковая последовательность А. Найти количество элементов А,
// которые содержат более одного символа и при этом начинаются и оканчиваются символом С;
class Program
{
    static void Main()
    {
        char c = 'c';//создаём символ и инициализируем его
        string[] line = {"caca", "coc", "caa3dac"};//создаём строковй массив и инициализируем его
        int count = line.Count(str => str.Length > 1 && str[0] == c && str[^1] == c);//получаем кол-во элементов в массиве,
                                                                                          //которые удовлетворяют условию: длина строки больше 1,
                                                                                          //первый символ "с" и последний символ "с"
        Console.WriteLine(count);
    }
}










