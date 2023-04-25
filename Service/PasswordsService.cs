using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxcvbn;


namespace Service
{
    public class PasswordsService : IPasswordsService
    {
        public int getPasswordRate(Password password)
        {
            return Zxcvbn.Core.EvaluatePassword(password.password).Score;
        }
    }
}
