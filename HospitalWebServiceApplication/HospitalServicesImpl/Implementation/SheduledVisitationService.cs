using HospitalServices.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServicesImpl.Implementation
{
    public class SheduledVisitationService : ISheduledVisitationService
    {
        public string GetVisitation(long id)
        {
            var resultSet = DatabaseConnection.getConnection().Scheduled_visitations.Where(visitation => visitation.visitation_Id == id).ToList();

            if (resultSet.Count == 1)
            {
                HospitalModels.ServiceModels.ScheduledVisitation visitation = new HospitalModels.ServiceModels.ScheduledVisitation();
                visitation.Map(resultSet.FirstOrDefault());
                return JsonConvert.SerializeObject(visitation);
            }
            return JsonConvert.SerializeObject(new { });
        }

        public string GetVisitationByPatientID(long patient_id)
        {
            List<HospitalModels.ServiceModels.ScheduledVisitation> histories = new List<HospitalModels.ServiceModels.ScheduledVisitation>();
            var resultSet = DatabaseConnection.getConnection().Scheduled_visitations.Where(visitation => visitation.patient_Id == patient_id).ToList();

            if (resultSet.Count > 0)
            {
                foreach (var visitation in resultSet)
                {
                    HospitalModels.ServiceModels.ScheduledVisitation temp = new HospitalModels.ServiceModels.ScheduledVisitation();
                    temp.Map(visitation);
                    histories.Add(temp);
                }
                return JsonConvert.SerializeObject(histories);
            }
            return JsonConvert.SerializeObject(new { });
        }

        public bool AddNewVisitation(long id, long patient_id, long hospital_id, long doctor_id, string reason, string diagnose, string date, string description)
        {
            throw new NotImplementedException();
        }
    }
}
