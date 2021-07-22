using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASN.Common.Entities;

namespace ASN.DAL.Contracts
{
    public interface IDao
    {
        IEnumerable<Message> GetMessages(Guid personId);
        IEnumerable<Person> GetAllPersons();
        IEnumerable<Shop> GetShops();
        Person GetPerson(Guid personId);
        Shop GetShop(Person person);
        Person Authenticate(string login, string password);
    }
}
