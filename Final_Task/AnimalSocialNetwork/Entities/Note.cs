using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASN.Common.Entities
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public byte[] Image { get; set; }
    }
}
