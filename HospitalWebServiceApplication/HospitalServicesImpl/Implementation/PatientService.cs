using HospitalServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace HospitalServicesImpl.Implementation
{
    public class PatientService : IPatientService
    {
        public string GetPatient(long patient_id)
        {
            //LocalHospitalDatabaseEntities database = new LocalHospitalDatabaseEntities();
            //var resultSet = database.Patients.Where(patient => patient.patient_id == patient_id).ToList();

            //if (resultSet.Count == 1)
            //{
            //    return JsonConvert.SerializeObject(resultSet.FirstOrDefault());
            //}

            //return JsonConvert.SerializeObject(new { });
            return null;
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
