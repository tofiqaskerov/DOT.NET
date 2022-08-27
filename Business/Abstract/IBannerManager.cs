using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBannerManager
    {
        void Add(Banner banner);
        Banner GetFirst();
        Banner Get(int id);
        void Remove(Banner banner);
        void Update(Banner banner);
    }
}
