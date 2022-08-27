using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IServicesDal : IEntityRepository<Services>
    {
        List<Services> GetServices();
        Services GetByIdWithCategory(int id);
    }
}
