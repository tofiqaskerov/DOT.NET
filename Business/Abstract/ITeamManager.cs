using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITeamManager
    {
        List<Team> GetTeams();
        Team GetTeam(int id);
        void Add(Team team);
        void Update(Team team); 
        void Remove(Team team);
    }
}
