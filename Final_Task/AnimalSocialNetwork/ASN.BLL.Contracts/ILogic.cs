using ASN.Common.Entities;
using ASN.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASN.BLL.Contracts
{
    public interface ILogic : IDao
    {
        Profile GetProfile(Guid id);
        IEnumerable<Profile> GetProfiles();
    }
}
