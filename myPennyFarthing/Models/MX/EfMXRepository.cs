using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace myPennyFarthing.Models
{
    public class EfMXRepository : IMXRepository
    {
        //   F I E L D S  &  P R O P E R T I E S
        private AppDbContext _context;


        //   C O N T R O L L E R S
        public EfMXRepository(AppDbContext context)
        {
            _context = context;
        }


        //   M E T H O D S
        //   C R E A T E
        public MX Create(MX mx)
        {
            _context.MXs.Add(mx);
            _context.SaveChanges();
            return mx;
        }


        //   R E A D
        public IQueryable<MX> GetAllMXs(int id)
        {
            return _context.MXs.Where(mx => mx.BikeId == id);

        }

        public MX GetMXById(int id)
        {
            return _context.MXs
                           .Include(mx => mx.Bike)
                           .FirstOrDefault(mx => mx.Id == id);
        }


        //   U P D A T E
        public MX Update(MX mx)
        {
            MX mxToUpdate = GetMXById(mx.Id);
            if (mxToUpdate != null)
            {
                mxToUpdate.Date = mx.Date;
                mxToUpdate.Action = mx.Action;
                mxToUpdate.Mileage = mx.Mileage;
                mxToUpdate.Cost = mx.Cost;
                _context.SaveChanges();
            }
            return mxToUpdate;

        }


        //   D E L E T E
        public bool Delete(MX mx)
        {
            MX mxToDelete = GetMXById(mx.Id);
            if (mxToDelete == null)
            {
                return false;
            }
            _context.MXs.Remove(mxToDelete);
            _context.SaveChanges();
            return true;
        }
    }
}
