using HospitalServices.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServicesImpl.Implementation
{
    public class DoctorService : IDoctorService
    {
        public string GetDoctor(long doctor_id)
        {
            var resultSet = DatabaseConnection.getConnection().Doctors.Where(doctor => doctor.doctor_Id == doctor_id).ToList();

            if (resultSet.Count == 1)
            {
                HospitalModels.ServiceModels.Doctor doctor = new HospitalModels.ServiceModels.Doctor();
                doctor.Map(resultSet.FirstOrDefault());
                return JsonConvert.SerializeObject(doctor);
            }

            return JsonConvert.SerializeObject(new { }); 
        }

        public string GetDoctorsByHospitalId(long hospital_id)
        {
            List<HospitalModels.ServiceModels.Doctor> doctors = new List<HospitalModels.ServiceModels.Doctor>();
            var resultSet = DatabaseConnection.getConnection().Doctors.Where(doctor => doctor.hospital_Id == hospital_id).ToList();

            if (resultSet.Count > 0)
            {
                foreach (var doctor in resultSet)
                {
                    HospitalModels.ServiceModels.Doctor temp = new HospitalModels.ServiceModels.Doctor();
                    temp.Map(doctor);
                    doctors.Add(temp);
                }
                return JsonConvert.SerializeObject(doctors);
            }
            return JsonConvert.SerializeObject(new { });
        }

        public string GetAllDoctors()
        {
            List<HospitalModels.ServiceModels.Doctor> doctors = new List<HospitalModels.ServiceModels.Doctor>();
            var resultSet = DatabaseConnection.getConnection().Doctors.ToList();

            if (resultSet.Count > 0)
            {
                foreach (var doctor in resultSet)
                {
                    HospitalModels.ServiceModels.Doctor temp = new HospitalModels.ServiceModels.Doctor();
                    temp.Map(doctor);
                    doctors.Add(temp);
                }
                return JsonConvert.SerializeObject(doctors);
            }
            return JsonConvert.SerializeObject(new { });
        }
    }
}
