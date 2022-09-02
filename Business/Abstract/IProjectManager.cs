using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProjectManager
    {
        List<Projects> GetAllProjects();
        void Add(Projects project);
        Projects Get(int id);
        Projects GetProjectsByCategory(int id);
        void Update(Projects project);  
        void Remove(Projects project);
    }
}
