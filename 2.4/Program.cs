using System.ComponentModel;

namespace _2._3;

public class program
{
    static void Main(string[] args)
    {
        runUser();
    }
    
    static void runUser()
    {
        int choice;
        
        do
        {
            Console.WriteLine("\n1 - Вход\n2 - Регистрация\n0 - Выход");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                login();
            }
            else if (choice == 2)
            {
                registr();
            }
        } while (choice != 0);
    }
    
    static void login()
    {
        using (context db = new context())
        {
            Console.WriteLine("\nВыберите пользователя: ");
            Console.WriteLine("0: Регистрация");
            
            var persons = db.Persons.ToList();
            for (int i = 0; i < persons.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {persons[i].login}");
            }
            
            int choice = int.Parse(Console.ReadLine());
            
            if (choice >= 1)
            {
                var person = persons[choice - 1];
                Console.WriteLine($"\nВведите пароль для: {person.login}");
                string password = Console.ReadLine();

                if (person.password == password)
                {
                    Console.WriteLine($"\nДобро пожаловать {person.login}!");
                    taskSelect();
                }
                else
                {
                    Console.WriteLine("Неверный пароль!");
                }
            }
            else
            {
               registr();
            }
        }
    }
    
    static void registr()
    {
        context db = new context(); 
        Console.Write("\nВведите логин: ");
        string login = Console.ReadLine();
        Console.Write("Введите пароль: ");
        string password = Console.ReadLine();
        
        Person newPerson = new Person()
        {
            login = login,
            password = password
        };
        
        db.Persons.Add(newPerson);
        db.SaveChanges();
        Console.WriteLine("\nРегистрация завершена!");
        runUser();
    }
    
    static void taskSelect()
    {
        Console.WriteLine("\n1 - Добавить задачу\n2 - Удалить задачу\n3 - Редактировать задачу\n4 - Просмотр задач\n5 - Сменить пользователя");
        int select = int.Parse(Console.ReadLine());

        switch (select)
        {
            case 1:
                addTask();
                break;
            case 2:
                deleteTask();
                break;
            case 3:
                editTask();
                break;
            case 4:
                viewTask();
                break;
            default:
                runUser();
                break;
        }
    }
     static void addTask()
    {
        context db = new context(); 
        Console.Write("\nНазвание: ");
        string name = Console.ReadLine();
        Console.Write("Описание: ");
        string description = Console.ReadLine();
        Console.Write("Дата: ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        
        Task newTask = new Task()
        {
            name = name,
            description = description,
            date = date
        };
        
        db.Tasks.Add(newTask);
        db.SaveChanges();
        Console.Write($"\nЗадача \"{name}\" добавлена!\n");
        taskSelect();
    }
    
    static void deleteTask()
    {
        context db = new context();
        
        Console.WriteLine("\nНомер задачи: "); 
        
        var tasks = db.Tasks.ToList(); 
        for (int i = 0; i < tasks.Count; i++) 
        { 
            Console.WriteLine($"{i + 1}: {tasks[i].name}");
        }
        
        int choice = int.Parse(Console.ReadLine());
        var task = tasks[choice - 1];
        
        db.Tasks.Remove(task);
        db.SaveChanges();
        Console.Write("\nЗадача удалена!\n");
        taskSelect();
    }
    
    static void editTask()
    {
        context db = new context();
        Console.WriteLine("\nНомер задачи: "); 
        
        var tasks = db.Tasks.ToList(); 
        for (int i = 0; i < tasks.Count; i++) 
        { 
            Console.WriteLine($"{i + 1}: {tasks[i].name}");
        }
        
        int choice = int.Parse(Console.ReadLine());
        var updateTask = db.Tasks.FirstOrDefault(t => t.id == choice); 
        Console.Write("\nНазвание: ");
        string newName = Console.ReadLine();
        Console.Write("Описание: ");
        string newDescription = Console.ReadLine();
        Console.Write("Дата: ");
        DateTime newDate = DateTime.Parse(Console.ReadLine());
       
        if (updateTask != null)
        {
            updateTask.name = newName;
            updateTask.description = newDescription;
            updateTask.date = newDate;
        }

        db.SaveChanges(); 
        Console.Write($"\nЗадача {newName} обновлена!\n");
        taskSelect();
    }
    
    static void viewTask()
    {
        context db = new context();
        Console.WriteLine("\n1 - на сегодня\n2 - на завтра\n3 - на неделю\n4 - выполнено\n5 - предстоящие\n6 - все задачи");
        int choice = int.Parse(Console.ReadLine());
        
        switch (choice)
        {
            case 1:
                var tasksToday = db.Tasks.Where(t => t.date.Date == DateTime.Today).ToList();
                if (tasksToday.Count > 0)
                {
                    foreach (var task in tasksToday)
                    {
                        Console.WriteLine($"\nId: {task.id} Название: {task.name} Описание: {task.description} Срок: {task.date.ToString("dd.MM.yyyy")}");
                    }
                }
                else
                {
                    Console.WriteLine("\nНа сегодня задач нет.");
                }
                taskSelect();
                break;
            case 2: 
                var tasksTomorrow = db.Tasks.Where(t => t.date.Date == DateTime.Today.AddDays(1)).ToList();
                
                if (tasksTomorrow.Count > 0)
                {
                    foreach (var task in tasksTomorrow)
                    {
                        Console.WriteLine($"\nId: {task.id} Название: {task.name} Описание: {task.description} Срок: {task.date.ToString("dd.MM.yyyy")}");
                    }
                }
                else
                {
                    Console.WriteLine("\nНа послезавтра задач нет.");
                }
                taskSelect();
                break;
            case 3:
                var tasksWeek = db.Tasks.Where(t => t.date.Date == DateTime.Today.AddDays(7)).ToList();
                var week = DateTime.Now.AddDays(7 - (int)DateTime.Now.DayOfWeek + 1).ToString("yyyy-MM-dd");
                if (tasksWeek.Count > 0)
                {
                    foreach (var task in tasksWeek)
                    {
                        Console.WriteLine($"\nId: {task.id} Название: {task.name} Описание: {task.description} Срок: {task.date.ToString("dd.MM.yyyy")}");
                    }
                }
                else
                {
                    Console.WriteLine("\nНа неделю задач нет.");
                }
                taskSelect();
                break;
            case 4:
                tasksToday = db.Tasks.Where(t => t.date.Date < DateTime.Today).ToList();
                if (tasksToday.Count > 0)
                {
                    foreach (var task in tasksToday)
                    {
                        Console.WriteLine($"\nId: {task.id} Название: {task.name} Описание: {task.description} Срок: {task.date.ToString("dd.MM.yyyy")}");
                    }
                }
                else
                {
                    Console.WriteLine("\nНа сегодня задач нет.");
                }
                taskSelect();
                break;
            case 5:
                tasksToday = db.Tasks.Where(t => t.date.Date > DateTime.Today).ToList();
                if (tasksToday.Count > 0)
                {
                    foreach (var task in tasksToday)
                    {
                        Console.WriteLine($"\nId: {task.id} Название: {task.name} Описание: {task.description} Срок: {task.date.ToString("dd.MM.yyyy")}");
                    }
                }
                else
                {
                    Console.WriteLine("\nНа сегодня задач нет.");
                }
                taskSelect();
                break;
            case 6:
                foreach (var task in db.Tasks)
                {
                    Console.WriteLine(
                            $"\nId: {task.id} Название: {task.name} Описание: {task.description} Срок: {task.date}");
                }
                taskSelect();
                break;
        }
    }
}