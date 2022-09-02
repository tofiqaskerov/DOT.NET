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
    public class RoleManager : IRoleManager
    {
        private readonly IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        public void Add(Roles role)
        {
            _roleDal.Add(role);
        }

        public Roles Get(int id)
        {
            return _roleDal.Get(x =>x.Id == id);
        }

        public List<Roles> GetAll()
        {
            return _roleDal.GetAll();
        }

        public void Remove(Roles role)
        {
            _roleDal.Delete(role);
        }

        public void Update(Roles role)
        {
            _roleDal.Update(role);  
        }
    }
}
