using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace MongoDB.ConsoleExample_1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new MongoClient("mongodb://root:example@localhost:27017");

            var database = client.GetDatabase("SupplementDB");

            var _supplement = database.GetCollection<Supplement>("Supplements");

            _supplement.InsertOne(new Supplement
            {
                SupplementName = "Тестовое имя",
                SupplementSubClass = new SupplementSubClass { Name = "Тестовый подкласс" },
                Collection = new System.Collections.Generic.List<SupplementSubClass> 
                { new SupplementSubClass { Name = "Тестовая коллекция" },
                  new SupplementSubClass { Name = "Тестовая коллекция" }}
            });

            var suppliment = await _supplement.Find(x => true).ToListAsync();

        }
    }
}
