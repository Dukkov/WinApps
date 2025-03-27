using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace BoardTest
{
    public enum Tiers
    {
        bronze,
        silver,
        gold,
        premium
    }
    public class Customer
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string MailAddress { get; set; }
        public Tiers Grade { get; set; }
        public string Product { get; set; }
        public int Point { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var faker = new Faker<Customer>("ko")
                .RuleFor(p => p.Id, (f, p) => (uint)f.IndexGlobal + 1)
                .RuleFor(p => p.Name, (f, p) => f.Name.FullName())
                .RuleFor(p => p.Contact, (f, p) => $"010-{f.Random.Replace("####-####")}")
                .RuleFor(p => p.MailAddress, (f, p) => new Faker("en").Internet.Email())
                .RuleFor(p => p.Grade, (f, p) => f.PickRandom<Tiers>())
                .RuleFor(p => p.Product, (f, p) => f.Commerce.ProductName())
                .RuleFor(p => p.Point, (f, p) => f.Random.Int());

            List<Customer> customers = faker.Generate(10);

            foreach (var customer in customers)
            {
                Console.WriteLine($"번호: {customer.Id}, 회원명: {customer.Name}, 연락처: {customer.Contact}, " +
                    $"메일주소: {customer.MailAddress}, 회원등급: {customer.Grade}, 이용중인 상품: {customer.Product}, " +
                    $"적립 포인트: {customer.Point}");
            }

            Console.ReadKey();
        }
    }
}
