using System.Collections.Generic;

namespace Core
{
    public interface IPersonRepository
    {
        Person Get(int id);
        IList<Person> GetAll();
    }
}