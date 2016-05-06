using HospitalServices.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServicesImpl.Implementation
{
    public class MedicalClinicService : IMedicalClinicService
    {
        public string GetHospital(long hospital_id)
        {
            var resultSet = DatabaseConnection.getConnection().Hospitals.Where(hospital => hospital.hospital_id == hospital_id).ToList();
         
            if (resultSet.Count == 1)
            {
                HospitalModels.ServiceModels.Hospital hospital = new HospitalModels.ServiceModels.Hospital();
                hospital.Map(resultSet.FirstOrDefault());
                return JsonConvert.SerializeObject(hospital);
            }

            return JsonConvert.SerializeObject(new { }); ;
        }

        public string GetAllHospitals()
        {
            List<HospitalModels.ServiceModels.Hospital> hospitals = new List<HospitalModels.ServiceModels.Hospital>();
            var resultSet = DatabaseConnection.getConnection().Hospitals.ToList();

            if (resultSet.Count > 0)
            {
                foreach (var hospital in resultSet)
                {
                    HospitalModels.ServiceModels.Hospital tempHospital = new HospitalModels.ServiceModels.Hospital();
                    tempHospital.Map(hospital);
                    hospitals.Add(tempHospital);
                }
                return JsonConvert.SerializeObject(hospitals);
            }
            return JsonConvert.SerializeObject(new { });
        }
    }
}
