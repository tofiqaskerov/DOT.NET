using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IServicesManager
    {
        List<Services> GetServices();
        void Add(Services services);
        Services Get(int id);
        void Remove(Services services);
        void Update(Services services);
    }
}
