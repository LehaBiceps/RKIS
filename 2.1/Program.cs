// using _2._1;
// internal class Program
// {
//     static void displayName(int i, string surname)
//     {
//         Console.WriteLine($"{i}: {surname}");
//     }
//     
//     static void displayStudents(List<Student> students)
//     {
//         Console.WriteLine("\nИнформация о студентах:");
//             
//         foreach (var student in students)
//         {
//             student.display();
//         }
//     }
//     
//     static void addStudent(List<Student> students)
//     { 
//         Student newStudents = new Student(); 
//         Console.WriteLine("Фамилия: "); 
//         newStudents.surname = Console.ReadLine();
//         Console.WriteLine("Дата рождения: "); 
//         newStudents.birthday = DateTime.Parse(Console.ReadLine());
//         Console.WriteLine("Номер группы: "); 
//         newStudents.group = int.Parse(Console.ReadLine()); 
//         Console.WriteLine("Оценки: ");
//         
//         for (int i = 0; i < 5; ++i)
//         {
//             newStudents.assessments[i] = int.Parse(Console.ReadLine());
//         }
//         students.Add(newStudents);
//     }
//
//     static void changeStudent(List<Student> students)
//     {
//         Console.WriteLine("Выберите студента: ");
//             
//         for (int i = 0; i < students.Count; ++i)
//         {
//             displayName(i, students[i].surname);
//         }
//         int serial = int.Parse(Console.ReadLine());
//             
//         Console.WriteLine($"\nВыбран {students[serial].surname}");
//         Console.WriteLine("Что поменять?\n1 - Фамилия\n2 - Дата рождения\n3 - Группа\n4 - Оценки"); // оценки
//         int choice = int.Parse(Console.ReadLine());
//             
//         if (choice != 1 && choice != 2 && choice != 3 && choice != 4)
//         {
//             Console.WriteLine("Ошибка");
//         }
//
//         switch (choice)
//         {
//             case 1: 
//                 Console.WriteLine("Введите фамилию: ");
//                 students[serial].surname = Console.ReadLine();
//                 Console.WriteLine("Данные обновленны\n");
//                 runProgram(students);
//                 break;
//             case 2:
//                 Console.WriteLine("Введите дату рождения: ");
//                 students[serial].birthday = DateTime.Parse(Console.ReadLine());
//                 Console.WriteLine("Данные обновленны\n");
//                 runProgram(students);
//                 break;
//             case 3:
//                 Console.WriteLine("Введите группу: ");
//                 students[serial].group = int.Parse(Console.ReadLine());
//                 Console.WriteLine("Данные обновленны\n");
//                 runProgram(students);
//                 break;
//             case 4:
//                 Console.WriteLine("Введите оценки: ");
//
//                 for (int i = 0; i < 5; ++i)
//                 {
//                     students[serial].assessments[i] = int.Parse(Console.ReadLine());
//                 }
//                 Console.WriteLine("Данные обновленны\n");
//                 runProgram(students);
//                 break;
//         }
//     }
//
//     static void runProgram(List<Student> students)
//     {
//         int temp;
//         do
//         { 
//             Console.WriteLine("1 - Добавить\n2 - Инфо\n3 - Изменить\n0 - Выход"); 
//             temp = int.Parse(Console.ReadLine()); 
//
//             if (temp == 1)
//             {
//                 addStudent(students);
//             }
//             else if (temp == 2)
//             {
//                 displayStudents(students);
//             }
//             else if (temp == 3)
//             {
//                 changeStudent(students);
//             }
//             else
//             {
//                 Environment.Exit(0);
//             }
//         } while (temp != 0);
//     }
//
//     public static void Main(string[] args)
//     {
//         List<Student> students = new List<Student>();
//         runProgram(students);
//     }
// }

















// using _2._1;
//
// internal class Program
// {
//     static void displayNum(int i, string numbers)
//     {
//         Console.WriteLine($"{i}: {numbers}");
//     }
//     
//     static void displayTrain(List<Train> trains)
//     {
//         Console.WriteLine("\nИнформация о поездах:");
//             
//         foreach (var train in trains)
//         {
//             train.display();
//         }
//     }
//     
//     static void addTrain(List<Train> trains)
//     { 
//         Train newTrain = new Train(); 
//         Console.WriteLine("Номер поезда: "); 
//         newTrain.number = Console.ReadLine();
//         Console.WriteLine("Пункт назначения: "); 
//         newTrain.destination = Console.ReadLine();
//         Console.WriteLine("Время отправления: "); 
//         newTrain.time = DateTime.Parse(Console.ReadLine()); 
//         trains.Add(newTrain);
//     }
//
//     static void changeTrain(List<Train> trains)
//     {
//         Console.WriteLine("Выберите поезд: ");
//             
//         for (int i = 0; i < trains.Count; ++i)
//         {
//             displayNum(i, trains[i].number);
//         }
//         int serial = int.Parse(Console.ReadLine());
//             
//         Console.WriteLine($"\nВыбран {trains[serial].number}");
//         Console.WriteLine("Что поменять?\n1 - Номер\n2 - Пункт прибытия\n3 - Время отправления");
//         int choice = int.Parse(Console.ReadLine());
//             
//         if (choice != 1 && choice != 2 && choice != 3)
//         {
//             Console.WriteLine("Ошибка");
//         }
//
//         switch (choice)
//         {
//             case 1: 
//                 Console.WriteLine("Введите номер поезда: ");
//                 trains[serial].number = Console.ReadLine();
//                 Console.WriteLine("Данные обновленны\n");
//                 runProgram(trains);
//                 break;
//             case 2:
//                 Console.WriteLine("Введите пункт прибытия: ");
//                 trains[serial].destination = Console.ReadLine();
//                 Console.WriteLine("Данные обновленны\n");
//                 runProgram(trains);
//                 break;
//             case 3:
//                 Console.WriteLine("Введите время отправления: ");
//                 trains[serial].time = DateTime.Parse(Console.ReadLine());
//                 Console.WriteLine("Данные обновленны\n");
//                 runProgram(trains);
//                 break;
//         }
//     }
//
//     static void runProgram(List<Train> trains)
//     {
//         
//         int temp;
//         do
//         { 
//             Console.WriteLine("1 - Добавить\n2 - Инфо\n3 - Изменить\n0 - Выход"); 
//             temp = int.Parse(Console.ReadLine()); 
//
//             if (temp == 1)
//             { 
//                 addTrain(trains);
//             }
//             else if (temp == 2)
//             {
//                 displayTrain(trains);
//             }
//             else if (temp == 3)
//             {
//                 changeTrain(trains);
//             }
//             else
//             {
//                 Environment.Exit(0);
//             }
//         } while (temp != 0);
//     }
//
//     public static void Main(string[] args)
//     {
//         List<Train> trains = new List<Train>();
//         runProgram(trains);
//     }
// }

















// using _2._1;
//
// internal class Program
// {
//
//     static void sum(Nums nums)
//     {
//         int sum = nums.a + nums.b;
//         Console.WriteLine("\nСумма: " + sum);
//     }
//
//     static void greatest(Nums nums)
//     {
//         if (nums.a > nums.b)
//         {
//             Console.WriteLine("\nНаибольшее: " + nums.a);
//         }
//         else
//         {
//             Console.WriteLine("\nНаибольшее: " + nums.b);
//         }
//     }
//     
//     static void change(Nums nums)
//     {
//         Console.WriteLine("\nВыберите число: ");
//         Console.WriteLine("1: " + nums.a);
//         Console.WriteLine("2: " + nums.b);
//         int choice = int.Parse(Console.ReadLine());
//
//         switch (choice)
//         {
//             case 1:
//                 Console.WriteLine("a = ");
//                 nums.a = int.Parse(Console.ReadLine());
//                 break;
//             case 2:
//                 Console.WriteLine("b = ");
//                 nums.b = int.Parse(Console.ReadLine());
//                 break;
//         }
//     }
//
//     public static void Main(string[] args)
//     {
//         Nums nums = new Nums();
//         int input;
//         Console.Write("а = ");
//         nums.a = int.Parse(Console.ReadLine());
//         Console.Write("b = ");
//         nums.b = int.Parse(Console.ReadLine());
//         do
//         {
//             Console.WriteLine("\n1 - сумма\n2 - наибольшее\n3 - изменить\n0 - выход");
//             input = int.Parse(Console.ReadLine());
//
//             switch (input)
//             {
//                 case 1:
//                     sum(nums);
//                     break;
//                 case 2:
//                     greatest(nums);
//                     break;
//                 case 3:
//                     change(nums);
//                     break;
//                 case 4:
//                     Environment.Exit(0);
//                     break;
//             }
//         } while (input != 0);
//     }
// }













//
//
//
// using _2._1;
//
// internal class Program
// {
//     static int up(Count counts)
//     {
//         return counts.count++;
//     }
//     
//     static int down(Count counts)
//     {
//         return counts.count--;
//     }
//
//     static int rnd(Count counts)
//     {
//         Random rnd = new Random();
//         counts.count = rnd.Next(-100, 100);
//         return counts.count;
//     }
//
//     public static void Main(string[] args)
//     {
//         Count counts = new Count();
//         Console.WriteLine("Значние по умолчанию: " + counts.count);
//         int input;
//         do
//         {
//             Console.WriteLine("1 - рандомное значение\n2 - увеличить на 1\n3 - уменьшить на 1\n0 - выход");
//             input = int.Parse(Console.ReadLine());
//
//             switch (input)
//             {
//                 case 1:
//                     Console.WriteLine("\n-----------\n" + "Новое значение: " + rnd(counts) + "\n-----------\n");
//                     break;
//                 case 2:
//                     Console.WriteLine("\n-----------\n" + "↑: " + up(counts) + "\n-----------\n");
//                     break;
//                 case 3:
//                     Console.WriteLine("\n-----------\n" + "↓: " + down(counts) + "\n-----------\n");
//                     break;
//             }
//         } while (input != 0);
//     }
// }


















