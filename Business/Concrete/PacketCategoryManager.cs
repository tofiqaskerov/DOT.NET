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
    public class PacketCategoryManager : IPacketCategoryManager
    {
        private readonly IPacketCategoryDal _packetCategoryDal;

        public PacketCategoryManager(IPacketCategoryDal packetCategoryDal)
        {
            _packetCategoryDal = packetCategoryDal;
        }

        public void Add(PacketCategory packetCategory)
        {
            _packetCategoryDal.Add(packetCategory);
        }

        public PacketCategory Get(int id)
        {
            return _packetCategoryDal.Get(x => x.Id == id);
        }

        public List<PacketCategory> GetAll()
        {
            return _packetCategoryDal.GetAll();
        }

        public void Remove(PacketCategory packetCategory)
        {
            _packetCategoryDal.Delete(packetCategory);
        }

        public void Update(PacketCategory packetCategory)
        {
            _packetCategoryDal.Update(packetCategory);
        }
    }
}
