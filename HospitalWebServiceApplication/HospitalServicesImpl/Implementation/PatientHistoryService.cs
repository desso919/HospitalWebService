using HospitalServices.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServicesImpl.Implementation
{
    public class PatientHistoryService : IPatientHistoryService
    {
        const int SUCCESSFULY_ADDED_ENTRY = 1;

        public string GetHistory(long id)
        {
            var ResultSet = DatabaseConnection.getConnection().Visitations.Where(visitation => visitation.id == id && visitation.isHistory == 1).ToList();

            if (ResultSet.Count == 1)
            {
                HospitalModels.ServiceModels.Visitation requestedHistory = new HospitalModels.ServiceModels.Visitation();
                requestedHistory.Map(ResultSet.FirstOrDefault());
                return JsonConvert.SerializeObject(requestedHistory);
            }

            return JsonConvert.SerializeObject(new { });
        }

        public string GetHistoryByPatientId(long patient_id)
        {
            List<HospitalModels.ServiceModels.Visitation> histories = new List<HospitalModels.ServiceModels.Visitation>();
            var resultSet = DatabaseConnection.getConnection().Visitations.Where(visitation => visitation.patient_id == patient_id && visitation.isHistory == 1).ToList();

            if (resultSet.Count > 0)
            {
                foreach (var history in resultSet)
                {
                    HospitalModels.ServiceModels.Visitation temp = new HospitalModels.ServiceModels.Visitation();
                    temp.Map(history);
                    histories.Add(temp);
                }
                return JsonConvert.SerializeObject(histories);
            }
            return JsonConvert.SerializeObject(new { });
        }


        public bool AddNewHospitalRecord(long patient_id, long hospital_id, long doctor_id, string reason, string diagnose, string date, string description)
        {
            int historiesCount = DatabaseConnection.getConnection().Visitations.Count();
            HospitalDatabase.Visitation visitation = new HospitalDatabase.Visitation();
            HospitalDatabase.HospitalDatabaseEntities db = DatabaseConnection.getConnection();
            visitation.id = historiesCount + 1;
            visitation.patient_id = patient_id;
            visitation.hospital_id = hospital_id;
            visitation.doctor_id = doctor_id;         
            visitation.reson = reason;
            visitation.isHistory = 1;
            visitation.dignose = diagnose;
            visitation.date = Convert.ToDateTime(date);
            if (visitation.description != null)
            {
                visitation.description = description;
            }

            db.Visitations.Add(visitation);
            int result = db.SaveChanges();

            if (result == SUCCESSFULY_ADDED_ENTRY)
            {
                return true;
            }

            return false;
        }
    }
}
