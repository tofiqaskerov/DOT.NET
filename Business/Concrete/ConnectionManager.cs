using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ConnectionManager : IConnectionManager
    {
        private readonly IConnectionDal _connectionDal;

        public ConnectionManager(IConnectionDal connectionDal)
        {
            _connectionDal = connectionDal;
        }

        public void Add(Connection connection)
        {
            _connectionDal.Add(connection);
        }

        public Connection Get(int id)
        {
            return _connectionDal.Get(x => x.Id == id);
        }

        public List<Connection> GetAll()
        {
            return _connectionDal.GetAll(); 
        }

        public void Remove(Connection connection)
        {
            _connectionDal.Delete(connection);
        }

        public void Update(Connection connection)
        {
            _connectionDal.Update(connection);
        }
    }
}
