using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entities
{
    public class Password 
    {
        public string password { get; set; }

        public Password(string password)
        {
            this.password = password;
        }
    }
}
