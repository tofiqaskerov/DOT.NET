using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concret.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class PacketDal : EfEntityRepositoryBase<Packet, AppDbContext>, IPacketDal
    {
        public Packet GetByCategory(int id)
        {
            using AppDbContext _context = new();
            var packetCategory = _context.Packets.Include(x => x.PacketCategory).FirstOrDefault(x =>x.Id == id);
            return packetCategory;
        }

        

        public List<Packet> GetPackets()
        {
            using var _context = new AppDbContext();
            var packets = _context.Packets.Include(x =>x.PacketCategory).ToList();
            return packets;
        }

        
    }
}
