using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
namespace myPennyFarthing.Models
{
    public class EfBikeRepository : IBikeRepository
    {
        //   F I E L D S  &  P R O P E R T I E S
        private AppDbContext _context;
        private IUserRepository _userRepository;


        //   C O N T R O L L E R S
        public EfBikeRepository(AppDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }


        //   M E T H O D S
        //   C R E A T E
        public Bike Create(Bike b)
        {
            if(_userRepository.IsUserLoggedIn())
            {
                b.UserId = _userRepository.GetLoggedInUserId();
                _context.Bikes.Add(b);
                _context.SaveChanges();
                return b;
            }
            return null;
        }


        //   R E A D
        public IQueryable<Bike> GetAllBikes()
        {
            if(_userRepository.IsUserLoggedIn())
            {
                return _context.Bikes.Where(b => b.UserId == _userRepository.GetLoggedInUserId());
            }
            Bike[] nobikes = new Bike[0];
            return nobikes.AsQueryable<Bike>();
        }

        public Bike GetBikeById(int id)
        {
            if(_userRepository.IsUserLoggedIn())
            {
                Bike b = _context.Bikes
                                 .FirstOrDefault(b => b.UserId == _userRepository.GetLoggedInUserId());
                return b;
            }
            return null;
        }

        //   U P D A T E
        public Bike Update(Bike b)
        {
            Bike bikeToUpdate = GetBikeById(b.Id);
            if (bikeToUpdate != null)
            {
                bikeToUpdate.Year = b.Year;
                bikeToUpdate.Make = b.Make;
                bikeToUpdate.Model = b.Model;
                bikeToUpdate.Color = b.Color;
                _context.SaveChanges();
            }
            return bikeToUpdate;

        }


        //   D E L E T E
        public bool Delete(int id)
        {
            Bike bikeToDelete = GetBikeById(id);
            if(bikeToDelete == null)
            {
                return false;
            }
            _context.Bikes.Remove(bikeToDelete);
            _context.SaveChanges();
            return true;
        }
    }
}
