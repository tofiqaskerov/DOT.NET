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
    public class PacketManager : IPacketManager
    {
        private readonly IPacketDal _packetDal;

        public PacketManager(IPacketDal packetDal)
        {
            _packetDal = packetDal;
        }

        public void Add(Packet packet)
        {
            _packetDal.Add(packet);
        }

        public Packet Get(int id)
        {
            return _packetDal.Get(x =>x.Id == id);
        }

        public Packet GetByCategory(int id)
        {
            return _packetDal.GetByCategory(id);
        }

        public List<Packet> GetPackets()
        {
            return _packetDal.GetPackets();
        }

        public void Remove(Packet packet)
        {
            _packetDal.Delete(packet);
        }

        public void Update(Packet packet)
        {
            _packetDal.Update(packet);
        }
    }
}
