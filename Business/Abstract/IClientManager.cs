using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IClientManager
    {
        List<Client> GetAll();
        void Add(Client client); 
        void Remove(Client client); 
        void Update(Client client); 
        Client Get(int id); 

    }
}
