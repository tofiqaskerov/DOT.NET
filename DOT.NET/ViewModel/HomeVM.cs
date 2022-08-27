using Entities.Concrete;

namespace DOT.NET.ViewModel
{
    public class HomeVM
    {
        public Banner Banner { get; set; }
        public About About { get; set; }
        public List<Services> Services { get; set; }
        public List<Category> Category { get; set; }
    }
}
