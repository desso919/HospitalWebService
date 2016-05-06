using HospitalServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HospitalDatabase;


namespace HospitalServicesImpl.Implementation
{
    public class PatientService : IPatientService
    {
        public string GetPatient(long patient_id)
        {
            HospitalDatabaseEntities database = new HospitalDatabaseEntities();
            var resultSet = database.Patients.Where(patient => patient.patient_Id == patient_id).ToList();

            if (resultSet.Count == 1)
            {
                return JsonConvert.SerializeObject(resultSet.FirstOrDefault());
            }

            return "Tashak";
            //return JsonConvert.SerializeObject(new { });           
        }

        public string GetPatientByUsernameAndPassword(string username, string password)
        {
            throw new NotImplementedException();
        }

        public string GetPatientByEGNAndPassword(string egn, string password)
        {
            throw new NotImplementedException();
        }
    }
}
