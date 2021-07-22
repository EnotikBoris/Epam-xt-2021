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
        private const string readMessageCommand = @"SELECT msg.MessageId
                                                    	, msg.Name
                                                    	, msg.TargetPerson
                                                    	, msg.CurrentPerson
                                                    FROM Message as msg";
        private const string readMessagesTextCommand = @"SELECT txt.Texts
                                                         FROM MessageTexts AS txt
                                                             WHERE txt.MessageID = '{0}'";
        private const string readAllPersonsCommand = "SELECT * FROM Person AS p";
        private const string readPersonCommand = @"SELECT *
                                                   FROM Person
                                                   	    WHERE Id = '{0}'";
        private const string readAllShopsCommand = @"SELECT s.Name
                                                    	, s.Adress
                                                    	, s.SizeType
                                                    	, s.ID
                                                    FROM Shop AS s";
        private const string readShopCommand = @"SELECT s.Name
                                                , s.Adress
                                                , s.SizeType
                                                , s.ID
                                              FROM Shop AS s
                                              	INNER JOIN Person AS p
                                              		ON p.ShopID = s.ID
                                              	WHERE p.Id = '{0}'";
        private const string authenticateCommand = @"SELECT *
                                                    FROM Person AS p
                                                    	WHERE p.Login = '{0}'
                                                    		AND p.Password = '{1}'";

        public IEnumerable<Person> GetAllPersons()
            => ReadData<Person>(readAllPersonsCommand, (reader, persons) =>
            {
                persons.Add(new Person
                {
                    Age = (int)reader["Age"],
                    DateOfBirth = (DateTime)reader["DateOfBirth"],
                    Id = (Guid)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Type = (string)reader["Type"],
                });
            });

        public IEnumerable<Message> GetMessages(Guid personId)
            => ReadData<Message>(readMessageCommand, (reader, messages) => 
            {
                var id = (Guid)reader["MessageId"];

                messages.Add(new Message
                {
                    MessageId = id,
                    Messages = ReadData<string>(string.Format(readMessagesTextCommand, id), (textReader, texts) => 
                    {
                        texts.Add((string)textReader["Texts"]);
                    }),
                    Name = (string)reader["Name"],
                    TargetPerson = GetPerson((Guid)reader["TargetPerson"]),
                    CurrentPerson = GetPerson((Guid)reader["CurrentPerson"]),
                });
            });

        public Person GetPerson(Guid personId)
            => ReadData<Person>(string.Format(readPersonCommand, personId), (reader, persons) =>
            {
                persons.Add(new Person
                {
                    Age = (int)reader["Age"],
                    DateOfBirth = (DateTime)reader["DateOfBirth"],
                    Id = (Guid)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Type = (string)reader["Type"],
                });
            }).FirstOrDefault();

        public Shop GetShop(Person person)
        => ReadData<Shop>(string.Format(readShopCommand, person.Id), (reader, shops) =>
        {
            shops.Add(new Shop
            {
                Name = (string)reader["Name"],
                Adress = (string)reader["Adress"],
                SizeType = (SizeType)(int)reader["SizeType"],
            });
        }).FirstOrDefault();

        public IEnumerable<Shop> GetShops()
            => ReadData<Shop>(readAllShopsCommand, (reader, shops) => 
            {
                shops.Add(new Shop
                {
                    Name = (string)reader["Name"],
                    Adress = (string)reader["Adress"],
                    SizeType = (SizeType)(int)reader["SizeType"],
                });
            });

        public Person Authenticate(string login, string password)
            => ReadData<Person>(string.Format(authenticateCommand, login, password), (reader, persons) =>
            {
                persons.Add(new Person
                {
                    Age = (int) reader["Age"],
                    DateOfBirth = (DateTime)reader["DateOfBirth"],
                    Id = (Guid)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Type = (string)reader["Type"],
                });
            }).FirstOrDefault();

private static IEnumerable<T> ReadData<T>(string commandText, Action<SqlDataReader, List<T>> readerAction)
        {
            using (var connection = new SqlConnection(_connectionString)) // Using принимает только объекты реализующие IDisposable. После выполнения блока кода, выполняется метод Dispose
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = commandText;//;

                return ReadData<T>(command, readerAction);
            }
        }

        private static List<T> ReadData<T>(SqlCommand command, Action<SqlDataReader, List<T>> readerAction)
        {
            var items = new List<T>();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    readerAction(reader, items);
                }
            }

            return items;
        }

        
    }
}