using HospitalServices.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServicesImpl.Implementation
{
    public class RecommendedVisistationService : IRecommendedVisistationService
    {

        public string GetRecommendedVisitation(long id)
        {
            var resultSet = DatabaseConnection.getConnection().Recommended_Visitations.Where(visitation => visitation.visitation_Id == id).ToList();

            if (resultSet.Count == 1)
            {
                HospitalModels.ServiceModels.RecommendedVisitation visitation = new HospitalModels.ServiceModels.RecommendedVisitation();
                visitation.Map(resultSet.FirstOrDefault());
                return JsonConvert.SerializeObject(visitation);
            }
            return JsonConvert.SerializeObject(new { });
        }

        public string GetRecommendedVisitationForPatient(int age)
        {
            List<HospitalModels.ServiceModels.RecommendedVisitation> visitations = new List<HospitalModels.ServiceModels.RecommendedVisitation>();
            var resultSet = DatabaseConnection.getConnection().Recommended_Visitations.Where(visitation => visitation.min_recommended_age < age && age < visitation.max_recommended_age).ToList();

            if (resultSet.Count > 0)
            {
                foreach (var visitation in resultSet)
                {
                    HospitalModels.ServiceModels.RecommendedVisitation temp = new HospitalModels.ServiceModels.RecommendedVisitation();
                    temp.Map(visitation);
                    visitations.Add(temp);
                }
                return JsonConvert.SerializeObject(visitations);
            }
            return JsonConvert.SerializeObject(new { });
        }
    }
}
