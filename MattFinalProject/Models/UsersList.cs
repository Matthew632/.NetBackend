using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class UsersList
    {
        public List<User> usersList { get; set; }
        public UsersList()
        {
            usersList = new List<User>();
        }
    }
}
