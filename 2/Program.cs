using System.ComponentModel;
using System.Net.NetworkInformation;
using Npgsql;

public class Program
{
    public static class DatabaseService
    {
        private static NpgsqlConnection? _connection;

        private static string GetConnectionString()
        {
            return @"Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=";
        }

        public static NpgsqlConnection GetSqlConnection()
        {
            if (_connection is null)
            {
                _connection = new NpgsqlConnection(GetConnectionString());
                _connection.Open();
            }

            return _connection;
        }
        
        public static void printDriver()
        {
            var querySql = "SELECT * FROM driver";
            using var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection());
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Id: {reader[0]} Имя: {reader[1]} Фамилия: {reader[2]} Дата рождения: {reader[3]}");
            }
        }

        static void car()
        {
            Console.WriteLine("\n1 - Просмотр типов т/с\n2 - Добавление типа т/с\n3 - Просмотр т/с\n4 - Добавление т/с");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: 
                    var querySql = "SELECT * FROM type_car";
                    using (var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection()))
                    {
                        using var reader = cmd.ExecuteReader();
                        Console.WriteLine();
                        
                        while (reader.Read())
                        {
                            
                            Console.WriteLine($"Id: {reader[0]} Название: {reader[1]}");
                        }
                        break;
                    }
                case 2:
                    Console.Write("\nВведите тип т/с: ");
                    string name = Console.ReadLine();
                    querySql = $"INSERT INTO type_car(name) VALUES ('{name}')";
                    using (var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection()))
                    {
                        cmd.ExecuteNonQuery();
                        break;
                    }
                case 3: 
                    querySql = "SELECT * FROM car";
                    using (var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection()))
                    {
                        using var car = cmd.ExecuteReader();

                        while (car.Read())
                        {
                            Console.WriteLine(
                                $"Id: {car[0]} Тип: {car[1]} Название: {car[2]} Номер: {car[3]} Вместимость :{car[4]}");
                        }
                        break;
                    }
                case 4:
                    Console.Write("\nId типа авто: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Название: ");
                    string carName = Console.ReadLine();
                    Console.Write("Номер: ");
                    string numbers = Console.ReadLine();
                    Console.Write("Кол-во пассажиров: ");
                    int passenger = int.Parse(Console.ReadLine());
                    querySql = $"INSERT INTO car(id_type_car, name, state_number, number_passengers) VALUES ('{id}', '{carName}', '{numbers}', '{passenger}')";
                    using (var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection()))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    break;
                default:
                    Console.WriteLine("Ошибка!");
                    car();
                    break;
            }
        }

        static void driver()
        {
            Console.WriteLine("\n1 - Просмотр водителей\n2 - Добавление водителей\n3 - Просмотр категорий\n4 - Добавление категории\n5 - Задать категорию водителю");
            int choice = int.Parse(Console.ReadLine());
            
            switch (choice)
            {
                case 1:
                    printDriver();
                    break;
                case 2:
                    Console.Write("\nИмя: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Фамилия: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Дата рождения: ");
                    string birthdate = Console.ReadLine();
                    var querySql = $"INSERT INTO driver(first_name, last_name, birthdate) VALUES ('{firstName}', '{lastName}', '{birthdate}')";
                    
                    using (var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection()))
                    {
                        cmd.ExecuteNonQuery();
                        break;
                    }
                case 3:
                    Console.WriteLine("\nВыберите водителя: ");
                    printDriver();
                    int driver = int.Parse(Console.ReadLine());
                    
                    querySql = "SELECT dr.first_name, dr.last_name, rc.name " +
                                   "FROM driver_rights_category " +
                                   "INNER JOIN driver dr on driver_rights_category.id_driver = dr.id " +
                                   "INNER JOIN rights_category rc on rc.id = driver_rights_category.id_rights_category " +
                                   $"WHERE dr.id = {driver};";
                    using (var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection()))
                    {
                        using var reader = cmd.ExecuteReader();
                        Console.WriteLine();
                        
                        while (reader.Read())
                        {
                            Console.WriteLine($"Имя: {reader[0]} Фамилия: {reader[1]} Категория прав: {reader[2]}");
                        }
                        break;
                    }
                case 4:
                    Console.Write("\nКатегория: "); 
                    string name = Console.ReadLine();
                    querySql = $"INSERT INTO rights_category(name) VALUES ('{name}')";
                    
                    using (var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection()))
                    {
                        cmd.ExecuteNonQuery();
                        break;
                    }
                case 5: 
                    Console.Write("id водителя: ");
                    int driverId = int.Parse(Console.ReadLine());
                    Console.Write("id категории: ");
                    int rightsCategory = int.Parse(Console.ReadLine());
                    querySql = $"INSERT INTO driver_rights_category(id_driver, id_rights_category) VALUES ({driverId}, {rightsCategory})";
                    using (var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection()))
                    {
                        cmd.ExecuteNonQuery();
                        break;
                    }
                default:
                    Console.WriteLine("Ошибка!");
                    car();
                    break;
            }
        }

        static void route()
        {
            Console.WriteLine("\n1 - Просмотр маршрутов\n2 - Добавление маршрутов\n");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    var querySql = "SELECT * FROM itinerary";
                    using (var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection()))
                    {
                        using var a = cmd.ExecuteReader();

                        while (a.Read())
                        {
                            Console.WriteLine(
                                $"Id: {a[0]} Пункты: {a[1]}");
                        }
                    }
                    break;
                case 2:
                    Console.Write("\nМаршрут: "); 
                    string name = Console.ReadLine();
                    querySql = $"INSERT INTO itinerary(name) VALUES ('{name}')";
                    
                    using (var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection()))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    break;
            }
        }
        
        static void flight()
        {
            Console.WriteLine("\n1 - Просмотр рейсов\n2 - Добавление рейсов\n");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    var querySql = "SELECT * FROM route";
                    using (var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection()))
                    {
                        using var b = cmd.ExecuteReader();

                        while (b.Read())
                        {
                            Console.WriteLine($"Id: {b[0]} Id водителя: {b[1]} Id авто: {b[2]} Id маршрута: {b[3]} Вместимость :{b[4]}");
                        }
                    }
                    break;
                case 2:
                    Console.Write("\nId водителя: "); 
                    int id_driver = int.Parse(Console.ReadLine());
                    Console.Write("Id авто: ");
                    int id_car = int.Parse(Console.ReadLine());
                    Console.Write("Id маршрута: ");
                    int id_itinerary = int.Parse(Console.ReadLine());
                    Console.Write("Вместимость: ");
                    int nums = int.Parse(Console.ReadLine());
                    querySql = $"INSERT INTO route(id_driver, id_car, id_itinerary, number_passengers) VALUES ('{id_driver}', '{id_car}', '{id_itinerary}', '{nums}')";
                    
                    using (var cmd = new NpgsqlCommand(querySql, DatabaseService.GetSqlConnection()))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    break;
            }
        }

        static void run()
        {
            Console.WriteLine("\n1 - Типы машин\n2 - Водители\n3 - Маршруты\n4 - Рейсы");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    car();
                    break;
                case 2:
                    driver();
                    break;
                case 3:
                    route();
                    break;
                case 4:
                    flight();
                    break;
                default:
                    Console.WriteLine("Ошибка!");
                    run();
                    break;
            }
        }

        public static void Main(string[] args)
        {
            run();
        }
    }
}