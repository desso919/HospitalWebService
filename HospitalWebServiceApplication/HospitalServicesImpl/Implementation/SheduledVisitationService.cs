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

        public bool AddNewVisitation(long patient_id, long hospital_id, long doctor_id, string date, string reason, string description)
        {
            int visitationsCount = DatabaseConnection.getConnection().Scheduled_visitations.Count();
            HospitalDatabase.Scheduled_visitations visitation = new HospitalDatabase.Scheduled_visitations();
            HospitalDatabase.HospitalDatabaseEntities db = DatabaseConnection.getConnection();
            visitation.visitation_Id = ++visitationsCount;
            visitation.patient_Id = patient_id;
            visitation.hospital_Id = hospital_id;
            visitation.doctor_Id = doctor_id;
            visitation.plan_date = Convert.ToDateTime(date);
            visitation.reson = reason;
            visitation.description = description;
         
            db.Scheduled_visitations.Add(visitation);
            int result = db.SaveChanges();

            if (result == HospitalUtill.SUCCESSFULY_ADDED_ENTRY)
            {
                return true;
            }

            return false;
        }
    }
}
