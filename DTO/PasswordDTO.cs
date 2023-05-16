using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PasswordDTO 
    {
        public string password { get; set; }

        public PasswordDTO(string password)
        {
            this.password = password;
        }
    }
}
