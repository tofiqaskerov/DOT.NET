using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProjectDal : IEntityRepository<Projects>
    {
        List<Projects> GetAllProjects();
        Projects GetProjectsByCategory(int id);
       
    }
}
