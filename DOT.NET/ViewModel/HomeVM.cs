using Entities.Concrete;

namespace DOT.NET.ViewModel
{
    public class HomeVM
    {
        public Banner Banner { get; set; }
        public About About { get; set; }
        public Location Location { get; set; }
        public List<Services> Services { get; set; }
        public List<Category> Category { get; set; }
        public List<Projects> Projects { get; set; }    
        public List<Packet> Packets { get; set; }
        public List<Team> Teams { get; set; }
        public List<Client> Clients { get; set; }   
       
    }
}
