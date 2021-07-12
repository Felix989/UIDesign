using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIDesign.User
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public UserDTO(string un, string pw) {
            UserName = un;
            Password = pw;
        }
    }
}
