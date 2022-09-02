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
    public class TeamManager : ITeamManager
    {
        private readonly ITeamDal _teamDal;

        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        public void Add(Team team)
        {
            _teamDal.Add(team); 
        }

        public Team GetTeam(int id)
        {
            return _teamDal.GetTeam(id);
        }

        public List<Team> GetTeams()
        {
            return _teamDal.GetTeams();
        }

        public void Remove(Team team)
        {
            _teamDal.Delete(team);
        }

        public void Update(Team team)
        {
            _teamDal.Update(team);
        }
    }
}
