using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServices.Interfaces
{
    public interface IPatientService
    {
        string GetPatient(long patient_id);

        string GetPatientByUsernameAndPassword(string username, string password);

        string GetPatientByEGNAndPassword(string egn, string password);

        bool AddNewPatient(string username, string password, string first_name, string second_name, string last_name, string egn, string gender, int age, string birth_date);
    }
}
