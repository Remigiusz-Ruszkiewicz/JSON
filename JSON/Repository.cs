using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON
{
    public class Repository
    {
        private string file = ConfigurationManager.AppSettings["file"];
        private List<Person> getPersonList
        {
            get
            {
                var data = File.ReadAllText(file);
                return JsonConvert.DeserializeObject<List<Person>>(data);
            }
        }
        private void serialize(List<Person> person)
        {
            string dataToSave = JsonConvert.SerializeObject(person);
            File.WriteAllText(ConfigurationManager.AppSettings["file"],
                JToken.Parse(dataToSave).ToString());
        }

        internal void Delete(string name)
        {
            var personlist = getPersonList;
            personlist.Remove(personlist.FirstOrDefault(x=>x.Name == name));
            serialize(personlist);
        }

        internal void Add(Person person)
        {
            var data = File.ReadAllText(file);
            var personlist = getPersonList;
            personlist.Add(person);

            
        }
        internal List<Person> GetList()
        {
            var data = File.ReadAllText(file);
            var personlist = getPersonList;
            
        }
    }
}
