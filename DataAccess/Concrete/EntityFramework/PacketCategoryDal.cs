using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concret.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class PacketCategoryDal : EfEntityRepositoryBase<PacketCategory, AppDbContext>, IPacketCategoryDal
    {
        public List<PacketCategory> GetAll()
        {
            using var _context = new AppDbContext();
            var packetCategory = _context.PacketCategories.ToList();
            return packetCategory;
        }
    }
}
