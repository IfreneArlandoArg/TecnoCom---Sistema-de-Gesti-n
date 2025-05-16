using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BLL
{
    public static class Encriptador
    {
        public static string HashearConSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytesTexto = Encoding.UTF8.GetBytes(texto);
                byte[] hashBytes = sha256.ComputeHash(bytesTexto);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}