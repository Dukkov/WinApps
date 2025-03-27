using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Bogus;
using System.Data.SQLite;
using System.Data;

namespace DataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string dbDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MyCRM");
            Directory.CreateDirectory(dbDirectory);
            string dbPath = Path.Combine(dbDirectory, "myCRM.db");

            if (!File.Exists(dbPath))
            {
                Console.WriteLine("DB 생성을 시작합니다.");
                CreateDatabase(dbPath);
            }
            else
            {
                Console.WriteLine("이미 DB가 존재합니다.");
                Console.ReadKey();
            }
        }

        static void CreateDatabase(string dbpath)
        {
            try
            {
                using (var conn = new SQLiteConnection($"Data Source={dbpath}"))
                {
                    conn.Open();

                    string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS customer (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        name TEXT NOT NULL,
                        contact TEXT NOT NULL,
                        email_address TEXT,
                        grade TEXT NOT NULL,
                        product TEXT NOT NULL,
                        point INTEGER NOT NULL,
                        memo TEXT
                    );";
                    using (var cmd = new SQLiteCommand(createTableQuery, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    var faker = new Faker<Customer>("ko")
                    .RuleFor(p => p.Name, (f, p) => f.Name.FullName())
                    .RuleFor(p => p.Contact, (f, p) => $"010-{f.Random.Replace("####-####")}")
                    .RuleFor(p => p.EmailAddress, (f, p) => new Faker("en").Internet.Email())
                    .RuleFor(p => p.Grade, (f, p) => f.PickRandom<Tiers>().ToString())
                    .RuleFor(p => p.Product, (f, p) => f.Commerce.ProductName())
                    .RuleFor(p => p.Point, (f, p) => f.Random.Int(-1000000, 10000000));

                    List<Customer> customers = faker.Generate(100000);

                    using (var transaction = conn.BeginTransaction())
                    {
                        string insertQuery = @"
                        INSERT INTO customer (name, contact, email_address, grade, product, point)
                        VALUES (@name, @contact, @email_address, @grade, @product, @point)
                        ;";

                        using (var cmd = new SQLiteCommand(insertQuery, conn, transaction))
                        {
                            var nameParam = cmd.Parameters.Add("@name", DbType.String);
                            var contactParam = cmd.Parameters.Add("@contact", DbType.String);
                            var emailParam = cmd.Parameters.Add("@email_address", DbType.String);
                            var gradeParam = cmd.Parameters.Add("@grade", DbType.String);
                            var productParam = cmd.Parameters.Add("@product", DbType.String);
                            var pointParam = cmd.Parameters.Add("@point", DbType.Int32);

                            foreach (var customer in customers)
                            {
                                nameParam.Value = customer.Name;
                                contactParam.Value = customer.Contact;
                                emailParam.Value = customer.EmailAddress ?? (object)DBNull.Value;
                                gradeParam.Value = customer.Grade;
                                productParam.Value = customer.Product;
                                pointParam.Value = customer.Point;

                                cmd.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                }

                Console.WriteLine("DB 생성 완료");
                Console.ReadKey();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }

    public enum Tiers
    {
        Bronze,
        Silver,
        Gold,
        Premium
    }

    public class Customer
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string EmailAddress { get; set; }    //nullable
        public string Grade { get; set; }
        public string Product { get; set; }
        public int Point { get; set; }
        public string Memo { get; set; }    //nullable
    }
}
