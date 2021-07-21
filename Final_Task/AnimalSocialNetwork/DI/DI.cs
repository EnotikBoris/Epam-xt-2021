using ASN.BLL.Contracts;
using ASN.BLL.Logics;
using ASN.DAL;
using ASN.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI
{
    public class DI
    {
        private IDao _dao;
        private ILogic _logic;

        public IDao GetDao()
        {
            if (_dao == null)
            {
                _dao = new ASNDao();
            }

            return _dao;
        }

        public ILogic GetLogic()
        {
            if (_logic == null)
            {
                _logic = new ASNLogic(GetDao());
            }

            return _logic;
        }
    }
}
