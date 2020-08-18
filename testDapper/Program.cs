using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace testDapper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // var dbcontext = new MyDbcontext();
            // dbcontext.Database.EnsureCreated();
            // dbcontext.Persons.Add(new Person { Id = 1, Name = "name"});
            // dbcontext.SaveChanges();

            // Console.WriteLine(JsonSerializer.Serialize(dbcontext.Persons.ToList()));

            var personDal = new PersonDAL();

            await personDal.Insert();

            var persons = await personDal.Get();

            Console.WriteLine(JsonSerializer.Serialize(persons));

            Console.ReadKey();
        }
    }
}