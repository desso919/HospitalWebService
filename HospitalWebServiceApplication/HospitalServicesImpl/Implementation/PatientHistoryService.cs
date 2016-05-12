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

        public string GetHistory(long history_id)
        {
            var ResultSet = DatabaseConnection.getConnection().Histories.Where(history => history.history_Id == history_id).ToList();

            HospitalModels.ServiceModels.PatientHistory requestedHistory = new HospitalModels.ServiceModels.PatientHistory();
            if (ResultSet.Count == 1)
            {
                requestedHistory.Map(ResultSet.FirstOrDefault());
                return JsonConvert.SerializeObject(requestedHistory);
            }

            return JsonConvert.SerializeObject(new { });
        }

        public string GetHistoryByPatientId(long patient_id)
        {
            List<HospitalModels.ServiceModels.PatientHistory> histories = new List<HospitalModels.ServiceModels.PatientHistory>();
            var resultSet = DatabaseConnection.getConnection().Histories.Where(history => history.patient_Id == patient_id).ToList();

            if (resultSet.Count > 0)
            {
                foreach (var history in resultSet)
                {
                    HospitalModels.ServiceModels.PatientHistory temp = new HospitalModels.ServiceModels.PatientHistory();
                    temp.Map(history);
                    histories.Add(temp);
                }
                return JsonConvert.SerializeObject(histories);
            }
            return JsonConvert.SerializeObject(new { });
        }


        public bool AddNewHospitalRecord(long patient_id, long hospital_id, long doctor_id, string reason, string diagnose, string date, string description)
        {
            int historiesCount = DatabaseConnection.getConnection().Scheduled_visitations.Count();
            HospitalDatabase.History history = new HospitalDatabase.History();
            HospitalDatabase.HospitalDatabaseEntities db = DatabaseConnection.getConnection();
            history.history_Id = historiesCount + 1;
            history.patient_Id = patient_id;
            history.hospital_Id = hospital_id;
            history.doctor_Id = doctor_id;         
            history.reson = reason;
            history.dignose = diagnose;
            history.date = Convert.ToDateTime(date);
            if (history.description != null)
            {
                history.description = description;
            }

            db.Histories.Add(history);
            int result = db.SaveChanges();

            if (result == SUCCESSFULY_ADDED_ENTRY)
            {
                return true;
            }

            return false;
        }
    }
}
