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
    public class ClientManager : IClientManager
    {
        private readonly IClientDal _clientDal;

        public ClientManager(IClientDal clientDal)
        {
            _clientDal = clientDal;
        }

        public void Add(Client client)
        {
            _clientDal.Add(client); 
        }

        public Client Get(int id)
        {
            return _clientDal.Get(x => x.Id == id);
        }

        public List<Client> GetAll()
        {
            return _clientDal.GetAll(); 
        }

        public void Remove(Client client)
        {
            _clientDal.Delete(client);
        }

        public void Update(Client client)
        {
            _clientDal.Update(client);
        }
    }
}
