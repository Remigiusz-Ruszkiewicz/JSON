using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repo = new Repository();
            //repo.Add(new Person
            //{
            //    LastName = "LN",
            //    Name = "N",
            //    ListOfObjects = new List<string> {"1","2"}
            //});
            //var list = repo.GetList();
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            repo.Delete("N");
            Console.WriteLine(repo.GetList());








            var data = File.ReadAllText(ConfigurationManager.AppSettings["file"]);
            JObject jsonObject = JObject.Parse(data);
            Console.WriteLine(jsonObject["name"]);
            var person = JsonConvert.DeserializeObject<List<Person>>(data);
            person.RemoveAt(0);

            string dataToSave = JsonConvert.SerializeObject(person);
            File.WriteAllText(ConfigurationManager.AppSettings["file"],
                JToken.Parse(dataToSave).ToString());
            ////Console.WriteLine(person[0]);
            ////Console.WriteLine(person[1]);
            Console.Read();
        }
    }
}
