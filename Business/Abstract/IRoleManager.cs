using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRoleManager
    {
        List<Roles> GetAll();
        Roles Get(int id);
        void Add(Roles role);
        void Remove(Roles role);
        void Update(Roles role);
    }
}
