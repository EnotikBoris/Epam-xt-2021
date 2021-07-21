using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASN.Common.Entities
{
    public class Message
    {
        public Guid MessageId { get; set; }
        public Person TargetPerson { get; set; }
        public Person CurrentPerson { get; set; }
        public IEnumerable<string> Messages { get; set; }
        public string Name { get; set; }
    }
}
