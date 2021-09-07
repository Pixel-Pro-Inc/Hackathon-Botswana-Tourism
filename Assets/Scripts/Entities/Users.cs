using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entities
{
    public class Users
    {
        public Users Instance { get; set; }
        public Users()
        {
        }

        public Users(string username, string email)
        {
            this.username = username;
            this.useremail = email;
        }
        public string username { get; set; }
        public string userid { get; set; }
        public string useremail { get; set; }
        public string userpassword { get; set; }
    }
}
