using System;
using System.Linq;

namespace myPennyFarthing.Models
{
    public interface IUserRepository
    {
        //   C R E A T E
        public User Create(User u);


        //   R E A D
        public IQueryable<User> GetAllUsers();
        public User GetUserByEmailAddress(string emailAddress);
        public User GetUserById(int id);
        public bool Login(User u);
        public void Logout();
        public bool IsUserLoggedIn();
        public int GetLoggedInUserId();
        public string GetLoggedInUserName();


        //   U P D A T E
        public bool ChangePassword(string oldPassword, string newPassword);
        public User Update(User u);


        //   D E L E T E
        public bool Delete(int id);
        public bool Delete(User u);
    }
}
