using Dapper;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace DapperConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = "Server=LAPTOP-KOQ9VHI4;Database=BookStoresDB;Trusted_Connection=True;";

            using (var db = new SqlConnection(connection))
            {
                var sqlInsert = $"INSERT INTO Author(last_name, first_name, phone) VALUES (@last_name, @first_name, @phone)";
                var restul = db.Execute(sqlInsert,
                    new
                    {
                        last_name = "Radhak",
                        first_name = "Sevann",
                        phone = "1173627795"
                    });

                var sql = "SELECT author_id, first_name, phone FROM Author";
                var list = db.Query<Author>(sql);

                //foreach (var author in list)
                //{
                //    Console.WriteLine(author.first_name);
                //}

                list.Select(a => { Console.WriteLine($"{a.author_id} | {a.first_name} {a.phone}"); return a; }).ToList();
            }
        }
    }
}
