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
    public static class DI
    {
        private static IDao _dao;
        private static ILogic _logic;

        public static IDao GetDao()
        {
            if (_dao == null)
            {
                _dao = new ASNDao();
            }

            return _dao;
        }

        public static ILogic GetLogic()
        {
            if (_logic == null)
            {
                _logic = new ASNLogic(GetDao());
            }

            return _logic;
        }
    }
}
