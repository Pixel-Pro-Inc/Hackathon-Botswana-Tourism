using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Entities
{
    class Users
    {
        public Users Instance { get; set; }
        public Users()
        {

        }

        public string username { get; set; }
        public string useremail { get; set; }
        public string userpassword { get; set; }
    }
}
