using ASN.Common.Entities;
using ASN.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASN.DAL
{
    public class ASNDao : IDao
    {
        private const string _connectionString = "Data Source=DESKTOP-7VLVODV;Initial Catalog=ANS-DB;Integrated Security=True";

        public IEnumerable<Person> GetAllPersons()
        {
            using (var connection = new SqlConnection(_connectionString)) // Using принимает только объекты реализующие IDisposable. После выполнения блока кода, выполняется метод Dispose
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Person";

                List<Person> persons = new List<Person>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var firstName = (string)reader["FirstName"];
                        var lastName = (string)reader["LastName"];
                        var id = (Guid)reader["Id"];
                        var age = (int)reader["Age"];
                        var date = (DateTime)reader["DateOfBirth"];
                        var type = (string)reader["Type"];
                        var imageRef = (string)reader["ImageRef"];

                        persons.Add(new Person 
                        { 
                            Age = age,
                            DateOfBirth = date,
                            Id = id,
                            FirstName = firstName,
                            LastName = lastName,
                            Type = type,
                        });
                    }
                }

                return persons;
            }

            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetMessages(Guid personId)
        {
            throw new NotImplementedException();
        }

        public Person GetPerson(Guid personId)
        {
            throw new NotImplementedException();
        }

        public Shop GetShop(Person person)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shop> GetShops()
        {
            throw new NotImplementedException();
        }
    }
}
