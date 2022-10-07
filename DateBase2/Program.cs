using System;
using System.Collections.Generic;
using MySql;
using MySql.Data.MySqlClient;

namespace DateBase2
{
    class Program
    {

        public const string connString = "server=localhost;user=root;database=residential_complex;port=3306;password=dashinka12131415";

        static void Main(string[] args)
        {
            for (int i = 1; i < 2; i++) {

                //Начальный интерфейс выбора
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("Выберите таблицу для работы:                              |");
                Console.WriteLine("R - residential_complex                                   |");
                Console.WriteLine("B - building                                              |");
                Console.WriteLine("-----------------------------------------------------------");
                Console.Write("");

                var Input_variable = Console.ReadLine();

                if (Input_variable == "R")
                {

                    Console.WriteLine("--------------------residential_complex--------------------");
                    Console.WriteLine("F - Вывести всю таблицу residential_complex               |");
                    Console.WriteLine("C - Получение строки                                      |");
                    Console.WriteLine("R - Добавление строки                                     |");
                    Console.WriteLine("U - Редактирование строки                                 |");
                    Console.WriteLine("D - Удаления строки                                       |");
                    Console.WriteLine("A - Аналитический запрос для таблицы                      |");
                    Console.WriteLine("AA - Втрой Аналитический запрос для таблицы               |");
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.Write("");

                    var Input_variable_R = Console.ReadLine();

                    if (Input_variable_R == "F") {

                        var res_coms_full = residential_complex_by_Full();

                        Console.WriteLine("---------------------------Вывод---------------------------");

                        foreach (var res_com in res_coms_full)
                        {

                            Console.WriteLine(res_com);
                        }

                        Console.WriteLine("-----------------------------------------------------------");

                    }
                    else if (Input_variable_R == "C")
                    {

                        Console.WriteLine("---------------------Получение строки----------------------");
                        Console.WriteLine("Введите значение location                                 |");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.Write("");

                        var Input_variable_RС = Console.ReadLine();

                        var res_coms_location = residential_complex_by_location(Input_variable_RС);

                        Console.WriteLine("---------------------------Вывод---------------------------");

                        foreach (var res_com in res_coms_location)
                        {

                            Console.WriteLine(res_com);
                        }

                        Console.WriteLine("-----------------------------------------------------------");

                    }
                    else if (Input_variable_R == "R")
                    {

                        Console.WriteLine("---------------------Добавление строки---------------------");
                        Console.WriteLine("Введите значение location, developer и title              |");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.Write("location- ");

                        var Input_variable_RRl = Console.ReadLine();

                        Console.Write("developer- ");

                        var Input_variable_RRd = Console.ReadLine();

                        Console.Write("title- ");

                        var Input_variable_RRt = Console.ReadLine();

                        residential_complex_by_add(Input_variable_RRl, Input_variable_RRd, Input_variable_RRt);

                        Console.WriteLine("---------------------------Вывод---------------------------");
                        Console.WriteLine("Запись успешно добавлена                                  |");
                        Console.WriteLine("-----------------------------------------------------------");


                    }
                    else if (Input_variable_R == "U")
                    {
                        Console.WriteLine("-------------------Редактирование строки-------------------");
                        Console.WriteLine("Введите id строки которую редактируем                     |");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.Write("id- ");

                        var Input_variable_RUid_Srt = Console.ReadLine();

                        var Input_variable_RUid = int.Parse(Input_variable_RUid_Srt);

                        var res_coms_id1 = residential_complex_by_id(Input_variable_RUid);

                        Console.WriteLine("-------------------Строка редактирования-------------------");

                        foreach (var res_com1 in res_coms_id1)
                        {

                            Console.WriteLine(res_com1);
                        }

                        Console.WriteLine("-----------------------------------------------------------");
                        Console.WriteLine("Введите значение location, developer и title              |");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.Write("location- ");

                        var Input_variable_RUl = Console.ReadLine();

                        Console.Write("developer- ");

                        var Input_variable_RUd = Console.ReadLine();

                        Console.Write("title- ");

                        var Input_variable_RUt = Console.ReadLine();

                        residential_complex_by_UPDATE(Input_variable_RUid, Input_variable_RUl, Input_variable_RUd, Input_variable_RUt);

                        var res_coms_id = residential_complex_by_id(Input_variable_RUid);

                        Console.WriteLine("---------------------------Вывод---------------------------");

                        foreach (var res_com in res_coms_id)
                        {

                            Console.WriteLine(res_com);
                        }

                        Console.WriteLine("Запись успешно изменена                                   |");
                        Console.WriteLine("-----------------------------------------------------------");


                    }
                    else if (Input_variable_R == "D")
                    {
                        Console.WriteLine("----------------------Удаления строки----------------------");
                        Console.WriteLine("Введите id строки которую удаляем                         |");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.Write("id- ");

                        var Input_variable_RDid_Srt = Console.ReadLine();

                        var Input_variable_RDid = int.Parse(Input_variable_RDid_Srt);

                        Console.WriteLine("---------------------------Вывод---------------------------");

                        var res_coms_id_drop = residential_complex_by_id(Input_variable_RDid);

                        residential_complex_by_drop(Input_variable_RDid); 

                        foreach (var res_com_d in res_coms_id_drop)
                        {

                            Console.WriteLine(res_com_d);
                        }

                        Console.WriteLine("-----------------------------------------------------------");

                    }
                    else if (Input_variable_R == "A")
                    {
                        Console.WriteLine("-------------------------Запрос----------------------------");
                        Console.WriteLine("Вывести все residential_complex в которых location        |");
                        Console.WriteLine("начинается на символ (Like @)                             |");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.Write("Символ для поиска- ");

                        var Input_variable_a1 = Console.ReadLine();

                        var res_coms_request = residential_complex_request(Input_variable_a1);

                        Console.WriteLine("---------------------------Вывод---------------------------");

                        foreach (var res_com in res_coms_request)
                        {

                            Console.WriteLine(res_com);
                        }

                        Console.WriteLine("-----------------------------------------------------------");


                    }
                    else if (Input_variable_R == "AA")
                    {
                        Console.WriteLine("-------------------------Запрос----------------------------");
                        Console.WriteLine("Вывести количество landscaping площадь которых            |");
                        Console.WriteLine("больше введеному числу                          |");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.Write("Площадь- ");

                        var Input_variable_a3_Str = Console.ReadLine();

                        var Input_variable_a3 = int.Parse(Input_variable_a3_Str);

                        var building_request_2 = residential_complex_request2(Input_variable_a3);

                        Console.WriteLine("---------------------------Вывод---------------------------");
                        Console.WriteLine(building_request_2);
                        Console.WriteLine("-----------------------------------------------------------");

                    }
                    else
                    {
                        Console.WriteLine("---------------------------Ошибка--------------------------");
                        Console.WriteLine("Введен неверный символ                                    |");
                        Console.WriteLine("-----------------------------------------------------------");

                    }
                }
                else if (Input_variable == "B")     //------------------------building---------------------------
                {

                    Console.WriteLine("-------------------------building--------------------------");
                    Console.WriteLine("F - Вывести всю таблицу building                          |");
                    Console.WriteLine("C - Получение строки                                      |");
                    Console.WriteLine("R - Добавление строки                                     |");
                    Console.WriteLine("U - Редактирование строки                                 |");
                    Console.WriteLine("D - Удаления строки                                       |");
                    Console.WriteLine("A - Аналитический запрос для таблицы                      |");
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.Write("");

                    var Input_variable_B = Console.ReadLine();

                    if (Input_variable_B == "F")
                    {

                        var build_full = building_by_Full();

                        Console.WriteLine("---------------------------Вывод---------------------------");

                        foreach (var build in build_full)
                        {

                            Console.WriteLine(build);
                        }

                        Console.WriteLine("-----------------------------------------------------------");

                    }
                    else if (Input_variable_B == "C")
                    {
                        Console.WriteLine("---------------------Получение строки----------------------");
                        Console.WriteLine("Введите значение address                                  |");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.Write("");

                        var Input_variable_BС = Console.ReadLine();

                        var build_addr = building_by_address(Input_variable_BС);

                        Console.WriteLine("---------------------------Вывод---------------------------");

                        foreach (var build in build_addr)
                        {

                            Console.WriteLine(build);
                        }

                        Console.WriteLine("-----------------------------------------------------------");

                    }
                    else if (Input_variable_B == "R")
                    {
                        Console.WriteLine("---------------------Добавление строки---------------------");
                        Console.WriteLine("Введите значение address и idresidential_complex          |");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.Write("address- ");

                        var Input_variable_BRa = Console.ReadLine();

                        Console.Write("idresidential_complex- ");

                        var Input_variable_BRi_Str = Console.ReadLine();

                        var Input_variable_BRi = int.Parse(Input_variable_BRi_Str);

                        building_by_add(Input_variable_BRa, Input_variable_BRi);

                        Console.WriteLine("---------------------------Вывод---------------------------");
                        Console.WriteLine("Запись успешно добавлена                                  |");
                        Console.WriteLine("-----------------------------------------------------------");

                    }
                    else if (Input_variable_B == "U")
                    {
                        Console.WriteLine("-------------------Редактирование строки-------------------");
                        Console.WriteLine("Введите id строки которую редактируем                     |");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.Write("id- ");

                        var Input_variable_BUid_Srt = Console.ReadLine();

                        var Input_variable_BUid = int.Parse(Input_variable_BUid_Srt);

                        var build_id1 = building_by_id(Input_variable_BUid);

                        Console.WriteLine("-------------------Строка редактирования-------------------");

                        foreach (var build1 in build_id1)
                        {

                            Console.WriteLine(build1);
                        }


                        Console.WriteLine("-----------------------------------------------------------");
                        Console.WriteLine("Введите значение address                                  |");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.Write("address- ");

                        var Input_variable_BUa = Console.ReadLine();

                        building_by_UPDATE(Input_variable_BUid, Input_variable_BUa, Input_variable_BUid);

                        var build_id2 = building_by_id(Input_variable_BUid);

                        Console.WriteLine("---------------------------Вывод---------------------------");

                        foreach (var build2 in build_id2)
                        {

                            Console.WriteLine(build2);
                        }

                        Console.WriteLine("Запись успешно изменена                                   |");
                        Console.WriteLine("-----------------------------------------------------------");

                    }
                    else if (Input_variable_B == "D")
                    {
                        Console.WriteLine("----------------------Удаления строки----------------------");
                        Console.WriteLine("Введите id строки которую удаляем                         |");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.Write("id- ");

                        var Input_variable_BDid_Srt = Console.ReadLine();

                        var Input_variable_BDid = int.Parse(Input_variable_BDid_Srt);

                        Console.WriteLine("---------------------------Вывод---------------------------");

                        var build_id_d = building_by_id(Input_variable_BDid);

                        building_by_drop(Input_variable_BDid);

                        foreach (var build_d in build_id_d)
                        {

                            Console.WriteLine(build_d);
                        }

                        Console.WriteLine("-----------------------------------------------------------");

                    }
                    else if (Input_variable_B == "A")
                    {
                        Console.WriteLine("-------------------------Запрос----------------------------");
                        Console.WriteLine("Вывести количество address из building,                   |");
                        Console.WriteLine("которые начинаются на символ (Like @)                     |");
                        Console.WriteLine("-----------------------------------------------------------");
                        Console.Write("Символ для поиска- ");

                        var Input_variable_a2 = Console.ReadLine();

                        var building_request = building_complex_request(Input_variable_a2);

                        Console.WriteLine("---------------------------Вывод---------------------------");
                        Console.WriteLine(building_request);
                        Console.WriteLine("-----------------------------------------------------------");

                    }
                    else
                    {
                        Console.WriteLine("---------------------------Ошибка--------------------------");
                        Console.WriteLine("Введен неверный символ                                    |");
                        Console.WriteLine("-----------------------------------------------------------");

                    }
                }
                else
                {

                    Console.WriteLine("---------------------------Ошибка--------------------------");
                    Console.WriteLine("Введен неверный символ                                    |");
                    Console.WriteLine("-----------------------------------------------------------");

                }

                i--;
            }
            
        }



        /*-------------------------------Функции--------------------------------*/

        static residential_complex[] residential_complex_by_Full()
        {

            var res_com = new List<residential_complex>();

            try
            {
                using var connection = new MySqlConnection(connString);

                connection.Open();

                using var command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM residential_complex.residential_complex;";

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res_com.Add(new residential_complex(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return res_com.ToArray();

        }


        static residential_complex[] residential_complex_by_location(String location)
        {

            var res_com = new List<residential_complex>();

            try
            {
                using var connection = new MySqlConnection(connString);

                connection.Open();

                using var command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM residential_complex where location = @location";

                command.Parameters.AddWithValue("@location", location);

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res_com.Add(new residential_complex(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return res_com.ToArray();

        }


        static void residential_complex_by_add(String location, String developer, String title)
        {
            try
            {
                using var connection = new MySqlConnection(connString);

                connection.Open();

                using var command = connection.CreateCommand();

                command.CommandText = "INSERT INTO residential_complex.residential_complex (location, developer, title) VALUES(@location, @developer, @title);";

                command.Parameters.AddWithValue("@location", location);
                command.Parameters.AddWithValue("@developer", developer);
                command.Parameters.AddWithValue("@title", title);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }


        static void residential_complex_by_UPDATE(int idresidential_complex, String location, String developer, String title)
        {
            try
            {
                using var connection = new MySqlConnection(connString);

                connection.Open();

                using var command = connection.CreateCommand();

                command.CommandText = "UPDATE residential_complex.residential_complex SET location = @location, developer = @developer, title = @title WHERE (idresidential_complex = @idresidential_complex);";

                command.Parameters.AddWithValue("@idresidential_complex", idresidential_complex);
                command.Parameters.AddWithValue("@location", location);
                command.Parameters.AddWithValue("@developer", developer);
                command.Parameters.AddWithValue("@title", title);

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }


        static void residential_complex_by_drop(int idresidential_complex)
        {

            int res_count = 0;
            try
            {
                using var connection1 = new MySqlConnection(connString);

                connection1.Open();

                using var command1 = connection1.CreateCommand();

                command1.CommandText = "select count(*) from building where idresidential_complex = @idresidential_complex;";

                command1.Parameters.AddWithValue("@idresidential_complex", idresidential_complex);

                using var reader = command1.ExecuteReader();

                reader.Read();

                res_count = reader.GetInt32(0);


                //---------------------------------
                if (res_count == 0)
                {

                    using var connection = new MySqlConnection(connString);

                    connection.Open();

                    using var command = connection.CreateCommand();

                    command.CommandText = "DELETE FROM residential_complex.residential_complex WHERE (idresidential_complex = @idresidential_complex);";

                    command.Parameters.AddWithValue("@idresidential_complex", idresidential_complex);

                    command.ExecuteNonQuery();
                }
                else {

                    Console.WriteLine("Ключ ссылается на другую таблицу");
                }

                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }


        static building[] building_by_address(String address)
        {

            var build = new List<building>();

            try
            {
                using var connection = new MySqlConnection(connString);

                connection.Open();

                using var command = connection.CreateCommand();

                command.CommandText = "select building.idbuilding, building.address, residential_complex.idresidential_complex, residential_complex.location, residential_complex.developer, residential_complex.title FROM building  join residential_complex on building.idresidential_complex = residential_complex.idresidential_complex  where address = @address;";

                command.Parameters.AddWithValue("@address", address);

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    build.Add(new building(reader.GetInt32(0), reader.GetString(1), new residential_complex(reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetString(5))));

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return build.ToArray();

        }


        static building[] building_by_Full()
        {

            var build = new List<building>();

            try
            {
                using var connection = new MySqlConnection(connString);

                connection.Open();

                using var command = connection.CreateCommand();

                command.CommandText = "select building.idbuilding, building.address, residential_complex.idresidential_complex, residential_complex.location, residential_complex.developer, residential_complex.title FROM building  join residential_complex on building.idresidential_complex = residential_complex.idresidential_complex;";

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    build.Add(new building(reader.GetInt32(0), reader.GetString(1), new residential_complex(reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetString(5))));


                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return build.ToArray();

        }


        static void building_by_add(String address, int idresidential_complex)
        {
            try
            {
                using var connection = new MySqlConnection(connString);

                connection.Open();

                using var command = connection.CreateCommand();

                command.CommandText = "INSERT INTO residential_complex.building (address, idresidential_complex) VALUES(@address, @idresidential_complex);";

                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@idresidential_complex", idresidential_complex);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }


        static void building_by_UPDATE(int idbuilding, String address, int idresidential_complex)
        {
            try
            {
                using var connection = new MySqlConnection(connString);

                connection.Open();

                using var command = connection.CreateCommand();

                command.CommandText = "UPDATE residential_complex.building SET address = @address, idresidential_complex = @idresidential_complex WHERE (idbuilding = @idbuilding);";

                command.Parameters.AddWithValue("@address", address);
                command.Parameters.AddWithValue("@idresidential_complex", idresidential_complex);
                command.Parameters.AddWithValue("@idbuilding", idbuilding);

                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }


        static void building_by_drop(int idbuilding)
        {
            try
            {
                using var connection = new MySqlConnection(connString);

                connection.Open();

                using var command = connection.CreateCommand();

                command.CommandText = "DELETE FROM residential_complex.building WHERE (idbuilding = @idbuilding);";

                command.Parameters.AddWithValue("@idbuilding", idbuilding);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }


        static residential_complex[] residential_complex_request(String location)
        {

            var res_com = new List<residential_complex>();

            try
            {
                using var connection = new MySqlConnection(connString);

                connection.Open();

                using var command = connection.CreateCommand();

                command.CommandText = "select * from residential_complex.residential_complex where location like @location '%'";

                command.Parameters.AddWithValue("@location", location);

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res_com.Add(new residential_complex(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return res_com.ToArray();

        }


        static int building_complex_request(String address)
        {

            int res = 0;

            try
            {
                using var connection = new MySqlConnection(connString);

                connection.Open();

                using var command = connection.CreateCommand();

                command.CommandText = "select count(*) FROM building join residential_complex on building.idresidential_complex = residential_complex.idresidential_complex  where address like @address '%';";

                command.Parameters.AddWithValue("@address", address);

                using var reader = command.ExecuteReader();

                reader.Read();

                res = reader.GetInt32(0);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return res;

        }


        static residential_complex[] residential_complex_by_id(int idresidential_complex)
        {

            var res_com = new List<residential_complex>();

            try
            {
                using var connection = new MySqlConnection(connString);

                connection.Open();

                using var command = connection.CreateCommand();

                command.CommandText = "SELECT * FROM residential_complex where idresidential_complex = @idresidential_complex";

                command.Parameters.AddWithValue("@idresidential_complex", idresidential_complex);

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    res_com.Add(new residential_complex(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));

                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return res_com.ToArray();

        }


        static building[] building_by_id(int idbuilding)
        {

            var build = new List<building>();

            try
            {
                using var connection = new MySqlConnection(connString);

                connection.Open();

                using var command = connection.CreateCommand();

                command.CommandText = "select building.idbuilding, building.address, residential_complex.idresidential_complex, residential_complex.location, residential_complex.developer, residential_complex.title FROM building  join residential_complex on building.idresidential_complex = residential_complex.idresidential_complex  where idbuilding = @idbuilding;";

                command.Parameters.AddWithValue("@idbuilding", idbuilding);

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    build.Add(new building(reader.GetInt32(0), reader.GetString(1), new residential_complex(reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetString(5))));


                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return build.ToArray();

        }


        static bool SaveFunction(string save) {

            bool res = true;
            //1. Пустота
            if (save == null) {

                res = false;


            }

            return res;
        }


        static int residential_complex_request2(int square)
        {

            int res = 0;

            try
            {
                using var connection = new MySqlConnection(connString);

                connection.Open();

                using var command = connection.CreateCommand();

                command.CommandText = "select count(*) FROM types_of_landscaping where square > @square;";

                command.Parameters.AddWithValue("@square", square);

                using var reader = command.ExecuteReader();

                reader.Read();

                res = reader.GetInt32(0);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return res;

        }

    }
}
