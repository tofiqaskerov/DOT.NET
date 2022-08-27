using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutManager
    {
        About GetFirst();
        About Get(int id);
        void Remove(About about);
        void Add(About about);
        void Update(About about);
    }
}
