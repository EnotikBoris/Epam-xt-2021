using ASN.BLL.Contracts;
using ASN.Common.Entities;
using ASN.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASN.BLL.Logics
{
    public class ASNLogic : ILogic
    {
        private IDao _dao;
        public ASNLogic(IDao dao)
        {
            _dao = dao;
        }

        public Person CurrentUser { get; private set; }

        public Person Authenticate(string login, string password)
        {
            CurrentUser = _dao.Authenticate(login, password);

            return CurrentUser;
        }

        public void CreateMessageText(Guid MessageId, string message)
        {
            _dao.CreateMessageText(MessageId, message);
        }

        public IEnumerable<Person> GetAllPersons()
            => _dao.GetAllPersons();

        public IEnumerable<Message> GetMessages(Guid personId)
            => _dao.GetMessages(personId);

        public Person GetPerson(Guid personId)
            => _dao.GetPerson(personId);

        public Profile GetProfile(Guid id)
        {
            var profile = new Profile()
            {
                Friends = _dao.GetAllPersons(),
                Messages = _dao.GetMessages(id),
                //Notes = _dao.GetNotes(id),
                Owner = GetPerson(id),
                Shop = _dao.GetShop(GetPerson(id)),
                //Status = 
            };

            return profile;
        }

        public IEnumerable<Profile> GetProfiles()
        {
            var persons = GetAllPersons();

            var profiles = new List<Profile>();

            foreach (var person in persons)
            {
                profiles.Add(GetProfile(person.Id));
            }

            return profiles;
        }

        public Shop GetShop(Person person)
            => _dao.GetShop(person);

        public IEnumerable<Shop> GetShops()
            => _dao.GetShops();
    }
}
