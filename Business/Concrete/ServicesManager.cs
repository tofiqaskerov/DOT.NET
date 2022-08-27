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
    public class ServicesManager : IServicesManager
    {
        private readonly IServicesDal _servicesDal;
        public ServicesManager(IServicesDal servicesDal)
        {
            _servicesDal = servicesDal;
        }

        public void Add(Services services)
        {
            _servicesDal.Add(services); 
        }

        public Services Get(int id)
        {
            return _servicesDal.GetByIdWithCategory(id);
        }

        public List<Services> GetServices()
        {
            return _servicesDal.GetServices();
        }

        public void Remove(Services services)
        {
            _servicesDal.Delete(services);
        }

        public void Update(Services services)
        {
            _servicesDal.Update(services);  
        }
    }
}
