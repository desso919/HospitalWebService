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


        public bool AddNewPatient(string username, string password, string first_name, string second_name, string last_name, string egn, string gender, int age, string birth_date)
        {
            int patientsCount = DatabaseConnection.getConnection().Patients.Count();
            HospitalDatabase.Patient patient = new HospitalDatabase.Patient();
            HospitalDatabase.HospitalDatabaseEntities db = DatabaseConnection.getConnection();
            patient.patient_Id = ++patientsCount;
            patient.username = username;
            patient.password = password;
            patient.first_name = first_name;           
            patient.last_name = last_name;
            patient.egn = egn;

            if (birth_date != null)
            {
                patient.birth_date = Convert.ToDateTime(birth_date);
            } 
            if (gender.Equals("Male"))
            {
                patient.gender_id = 1;
            }
            else if (gender.Equals("Female")) 
            {
                 patient.gender_id = 2;
            }

            db.Patients.Add(patient);
            int result = db.SaveChanges();

            if (result == HospitalUtill.SUCCESSFULY_ADDED_ENTRY)
            {
                return true;
            }

            return false;
        }
    }
}
