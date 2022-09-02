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
    public class LocationManager : ILocationManager
    {
        private readonly ILocationDal _locationDal;

        public LocationManager(ILocationDal locationDal)
        {
            _locationDal = locationDal;
        }

        public void Add(Location location)
        {
            _locationDal.Add(location);
        }

        public Location Get(int id)
        {
            return _locationDal.Get(x => x.Id == id);
        }

        public Location GetFirst()
        {
            return _locationDal.GetFirst();
        }

        public void Update(Location location)
        {
            _locationDal.Update(location);
        }
    }
}
