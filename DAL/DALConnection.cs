using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public abstract class DALConnection
    {
        protected string connectionString = "Integrated Security = SSPI; Data Source = .; Initial Catalog = TecnoComDB;";
    }
}