using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASN.Common.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Type { get; set; }
        public byte[] Image { get; set; }
        public Shop Shop { get; set; }
        [Obsolete("Вынести в отдельную сущность и таблицу")]
        public string Login { get; set; }
        [Obsolete("Вынести в отдельную сущность и таблицу")]
        public string Password { get; set; }
    }
}
