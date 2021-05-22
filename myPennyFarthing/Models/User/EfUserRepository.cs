using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;

namespace myPennyFarthing.Models
{
    public class EfUserRepository : IUserRepository
    {
        //   F I E L D S  &  P R O P E R T I E S
        private AppDbContext _context;
        private ISession _session;


        //   C O N T R O L L E R S
        public EfUserRepository(AppDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _session = httpContext.HttpContext.Session;
        }


        //   M E T H O D S
        //   C R E A T E
        public User Create(User u)
        {
            string encryptedPassword = EncryptPassword(u.Password);
            u.Password = encryptedPassword;

            User existingUser = GetUserByEmailAddress(u.UserName);
            if(existingUser != null)
            {
                return null;
            }
            _context.Users.Add(u);
            _context.SaveChanges();
            return u;
        }


        //   R E A D
        public IQueryable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public User GetUserByEmailAddress(string emailAddress)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == emailAddress);
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public bool Login(User user)
        {
            string encPassword = EncryptPassword(user.Password);

            User existingUser = _context.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == encPassword);

            if(existingUser == null || existingUser.Password != encPassword)
            {
                return false;
            }
            else
            {
                _session.SetInt32("userid", existingUser.Id);
                _session.SetString("username", user.UserName);
                return true;
            }
        }

        public void Logout()
        {
            _session.Remove("userid");
            _session.Remove("username");
        }

        public bool IsUserLoggedIn()
        {
            int? userId = _session.GetInt32("userid");
            if(userId == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int GetLoggedInUserId()
        {
            int? userId = _session.GetInt32("userid");
            if (userId == null)
            {
                return -1;
            }
            else
            {
                return userId.Value;
            }
        }

        public string GetLoggedInUserName()
        {
            return _session.GetString("username");
        }



        //   U P D A T E
        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if(!IsUserLoggedIn())
            {
                return false;
            }

            User userToUpdate = GetUserById(GetLoggedInUserId());
            if(userToUpdate != null && userToUpdate.Password != oldPassword)
            {
                userToUpdate.Password = newPassword;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public User Update(User u)
        {
            User userToUpdate = GetUserById(u.Id);
            if(userToUpdate != null)
            {
                userToUpdate.Password = u.Password;
                _context.SaveChanges();
            }
            return userToUpdate;
        }


        //   D E L E T E
        public bool Delete(int id)
        {
            User userToDelete = GetUserById(id);
            if(userToDelete == null)
            {
                return false;
            }
            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(User u)
        {
            return Delete(u.Id);
        }


        //   P R I V A T E   M E T H O D S
        private string EncryptPassword(string password)
        {
            SHA256 hashAlgorithm = SHA256.Create();

            byte[] passwordArray = Encoding.ASCII.GetBytes(password);

            byte[] encryptedPasswordArray = hashAlgorithm.ComputeHash(passwordArray);

            string result = BitConverter.ToString(encryptedPasswordArray);

            result = result.Replace("-", "");

            return result;
        }

        private string GenerateRandomPassword(int length = 8)
        {
            Random r = new Random();
            string result = "";
            for(int i = 0; i < length; i++)
            {
                result = result + (char)r.Next(33, 126);
            }
            return result;
        }
    }
}
