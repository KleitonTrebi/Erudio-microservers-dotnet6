using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public interface IPersonService
    {
        Person Creator(Person person);

        Person FindID(long id);

        List<Person> FindAll();

        Person Update(Person person);

        void Delete(long id);

    }
}
