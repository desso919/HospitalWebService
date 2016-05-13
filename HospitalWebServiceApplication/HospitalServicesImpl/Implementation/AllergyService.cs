using HospitalServices.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServicesImpl.Implementation
{
    public class AllergyService : IAllergyService
    {
        public string GetPatientAllergies(long patient_id)
        {
            throw new NotImplementedException();
        }

        public string GetAllAllergies()
        {
            //List<HospitalModels.ServiceModels.Allergy> allergies = new List<HospitalModels.ServiceModels.Allergy>();
            //var resultSet = DatabaseConnection.getConnection().Allergies.Select(allergy => allergy).ToList();

            //if (resultSet.Count > 0)
            //{
            //    foreach (var history in resultSet)
            //    {
            //        HospitalModels.ServiceModels.Allergy allergy = new HospitalModels.ServiceModels.Allergy();
            //        allergy.Map(history);
            //        allergies.Add(allergy);
            //    }
            //    return JsonConvert.SerializeObject(allergies);
            //}
            return JsonConvert.SerializeObject(new { });
        }
    }
}
