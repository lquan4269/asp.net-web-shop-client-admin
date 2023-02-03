using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class UserManager
    {
        Model1 db = new Model1();
        public bool CheckUserName(string Name) {
            List<User> userList = (from user in db.Users where user.Name == Name select user).ToList();
            if (userList.Count == 1)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }

        public bool CheckEmail(string Email)
        {
            List<User> emailList = (from user in db.Users where user.Email == Email select user).ToList();
            if (emailList.Count == 1)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool CheckPassowrd(string Password) {
            List<User> passwordList = (from user in db.Users where user.Password == Password select user).ToList();
            if (passwordList.Count == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckLogin(string Email, String Password)
        {
            User user = db.Users.Where(m => m.Email == Email).FirstOrDefault();
            if (user != null)
            {
                if (user.Password == Encrypt.MD5Hash(Password)) 
                    return true;
            }
            return false;
        }
    }
}