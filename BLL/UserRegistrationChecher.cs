using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public interface IUserRegistrationChecher
    {
         bool IsUserRegistered(string pEmail, string pPassword, out BEUsuario UserFound);
    }
}