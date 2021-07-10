using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASN.Common.Entities
{
    class Profile
    {
        public Person Owner { get; set; }
        public Shop Shop { get; set; }
        public string Status { get; set; }
        public IEnumerable<Person> Friends { get; set; }
        public IEnumerable<Note> Notes { get; set; }
        public IEnumerable<Message> Messages { get; set; }    
    }
}
