using HospitalDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServicesImpl.Implementation
{
    public class DatabaseConnection
    {
        public static HospitalDatabaseEntities getConnection()
        {
            return new HospitalDatabaseEntities();
        }
    }
}
