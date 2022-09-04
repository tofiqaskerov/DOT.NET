using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IConnectionManager
    {
        List<Connection> GetAll();
        Connection Get(int id);
        void Add(Connection connection);    
        void Update(Connection connection); 
        void Remove(Connection connection); 
    }
}
