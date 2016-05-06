using HospitalServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HospitalDatabase;
using HospitalModels.ServiceModels;
using AutoMapper;


namespace HospitalServicesImpl.Implementation
{
    public class PatientService : IPatientService
    {
        public string GetPatient(long patient_id)
        {
            var resultSet = DatabaseConnection.getConnection().Patients.Where(patient => patient.patient_Id == patient_id).ToList();

            if (resultSet.Count == 1)
            {
                HospitalModels.ServiceModels.Patient patient = new HospitalModels.ServiceModels.Patient();
                patient.Map(resultSet.FirstOrDefault());
                return JsonConvert.SerializeObject(patient);
            }

            return JsonConvert.SerializeObject(new { });           
        }

        public string GetPatientByUsernameAndPassword(string username, string password)
        {
            var resultSet = DatabaseConnection.getConnection().Patients.Where(patient => patient.username.Equals(username) && patient.password.Equals(password)).ToList();

            if (resultSet.Count == 1)
            {
                HospitalModels.ServiceModels.Patient patient = new HospitalModels.ServiceModels.Patient();
                patient.Map(resultSet.FirstOrDefault());
                return JsonConvert.SerializeObject(patient);
            }

            return JsonConvert.SerializeObject(new { });  
        }

        public string GetPatientByEGNAndPassword(string egn, string password)
        {
            var resultSet = DatabaseConnection.getConnection().Patients.Where(patient => patient.egn.Equals(egn) && patient.password.Equals(password)).ToList();

            if (resultSet.Count == 1)
            {
                HospitalModels.ServiceModels.Patient patient = new HospitalModels.ServiceModels.Patient();
                patient.Map(resultSet.FirstOrDefault());
                return JsonConvert.SerializeObject(patient);
            }

            return JsonConvert.SerializeObject(new { }); ;
        }
    }
}
