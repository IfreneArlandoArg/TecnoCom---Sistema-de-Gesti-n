using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BLLUsuario : UserRegistrationChecher
    {
        public override bool IsUserRegistered(string pEmail, string pPassword, out BEUsuario UserFound)
        {
            throw new NotImplementedException();
        }
    }
}