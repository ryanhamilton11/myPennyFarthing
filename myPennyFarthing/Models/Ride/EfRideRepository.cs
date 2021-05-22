using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace myPennyFarthing.Models
{
    public class EfRideRepository : IRideRepository
    {
        //   F I E L D S  &  P R O P E R T I E S
        private AppDbContext _context;


        //   C O N T R O L L E R S
        public EfRideRepository(AppDbContext context)
        {
            _context = context;
        }


        //   M E T H O D S
        //   C R E A T E
        public Ride Create(Ride r)
        {
            _context.Rides.Add(r);
            _context.SaveChanges();
            return r;
        }


        //   R E A D
        public IQueryable<Ride> GetAllRides(int id)
        {
            return _context.Rides.Where(r => r.BikeId == id);
        }

        public Ride GetRideById(int id)
        {
            return _context.Rides
                           .Include(r => r.Bike)
                           .FirstOrDefault(r => r.Id == id);
        }

        //   U P D A T E
        public Ride Update(Ride r)
        {
            Ride rideToUpdate = GetRideById(r.Id);
            if (rideToUpdate != null)
            {
                rideToUpdate.Date = r.Date;
                rideToUpdate.Time = r.Time;
                rideToUpdate.AvgCadence = r.AvgCadence;
                rideToUpdate.AvgHR = r.AvgHR;
                rideToUpdate.AvgSpeed = r.AvgSpeed;
                rideToUpdate.Ascent = r.Ascent;
                rideToUpdate.Descent = r.Descent;
                rideToUpdate.HighGrade = r.HighGrade;
                rideToUpdate.LowGrade = r.LowGrade;
                _context.SaveChanges();
            }
            return rideToUpdate;
        }


        //   D E L E T E
        public bool Delete(Ride r)
        {
            Ride rideToDelete = GetRideById(r.Id);
            if (rideToDelete == null)
            {
                return false;
            }
            _context.Rides.Remove(rideToDelete);
            _context.SaveChanges();
            return true;
        }       
    }
}
