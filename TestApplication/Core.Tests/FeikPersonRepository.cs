using System.Collections.Generic;
using System.Linq;

namespace Core.Tests
{
    class FeikPersonRepository : IPersonRepository
    {
        public IList<Person> Persons = new List<Person>();

        public Person Get(int id)
        {
            return Persons.FirstOrDefault(d => d.Id == id);
        }
        public IList<Person> GetAll()
        {
            return Persons;
        }
    }
}
