using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILocationManager
    {
        Location Get(int id);
        Location GetFirst();
        void Add(Location location);
        void Update(Location location);
    }
}
