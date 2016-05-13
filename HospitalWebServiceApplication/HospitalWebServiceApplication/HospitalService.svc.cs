using HospitalServices.Interfaces;
using HospitalServicesImpl.Implementation;
using NinjectBoot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Ninject;

namespace HospitalWebServiceApplication
{
    public class HospitalService : IHospitalService
    {
        public HospitalService()
        {
            BootNinjectConfiguration.ConfigureContainer();
        }

        #region Patient Service 
       
        public string GetPatient(long id)
        {           
            var service = BootNinjectConfiguration.Kernel.Get<IPatientService>();
            return service.GetPatient(id);
        }

        public string GetPatientByUsernameAndPassword(string username, string password)
        {
            var service = BootNinjectConfiguration.Kernel.Get<IPatientService>();
            return service.GetPatientByUsernameAndPassword(username, password);
        }

        public string GetPatientByEGNAndPassword(string egn, string password)
        {
            var service = BootNinjectConfiguration.Kernel.Get<IPatientService>();
            return service.GetPatientByEGNAndPassword(egn, password);
        }

        public bool AddNewPatient(string username, string password, string first_name, string second_name, string last_name, string egn, string gender, int age, string birth_date)
        {
            var service = BootNinjectConfiguration.Kernel.Get<IPatientService>();
            return service.AddNewPatient(username, password, first_name, second_name, last_name, egn, gender, age, birth_date);
        }

        #endregion

        #region Hospital Services
        public string GetHospital(long id)
        {
            var service = BootNinjectConfiguration.Kernel.Get<IMedicalClinicService>();
            return service.GetHospital(id);
        }

        public string GetAllHospitals()
        {
            var service = BootNinjectConfiguration.Kernel.Get<IMedicalClinicService>();
            return service.GetAllHospitals();
        }
        #endregion

        #region Doctor Services
        public string GetDoctor(long id)
        {
            var service = BootNinjectConfiguration.Kernel.Get<IDoctorService>();
            return service.GetDoctor(id);
        }

        public string GetDoctorsByHospitalId(long hospital_id)
        {
            var service = BootNinjectConfiguration.Kernel.Get<IDoctorService>();
            return service.GetDoctorsByHospitalId(hospital_id);
        }

        public string GetAllDoctors()
        {
            var service = BootNinjectConfiguration.Kernel.Get<IDoctorService>();
            return service.GetAllDoctors();
        }
        #endregion

        #region Allergies Services
        public string GetPatientAllergies(long patient_id)
        {
            throw new NotImplementedException();
        }

        public string GetAllAllergies()
        {
            var service = BootNinjectConfiguration.Kernel.Get<IAllergyService>();
            return service.GetAllAllergies();
        }
        #endregion

        #region Patient History Services

        public string GetHospitalRecord(long id)
        {
            var service = BootNinjectConfiguration.Kernel.Get<IPatientHistoryService>();
            return service.GetHistory(id);
        }

        public string GetHospitalRecordByPatientID(long patient_id)
        {
            var service = BootNinjectConfiguration.Kernel.Get<IPatientHistoryService>();
            return service.GetHistoryByPatientId(patient_id);
        }

        public bool AddNewHospitalRecord(long patient_id, long hospital_id, long doctor_id, string reason, string diagnose, string date, string description)
        {
            var service = BootNinjectConfiguration.Kernel.Get<IPatientHistoryService>();
            return service.AddNewHospitalRecord(patient_id, hospital_id, doctor_id, reason, diagnose, date, description);
        }

        #endregion

        #region Sheduled Visitations Services
        public string GetVisitation(long id)
        {
            var service = BootNinjectConfiguration.Kernel.Get<ISheduledVisitationService>();
            return service.GetVisitation(id);
        }

        public string GetVisitationByPatientID(long patient_id)
        {
            var service = BootNinjectConfiguration.Kernel.Get<ISheduledVisitationService>();
            return service.GetVisitationByPatientID(patient_id);
        }

        public bool MakeVisitationHistory(long id, string diagnose)
        {
            var service = BootNinjectConfiguration.Kernel.Get<ISheduledVisitationService>();
            return service.MakeVisitationHistory(id, diagnose);
        }

        public bool AddNewVisitation(long patient_id, long hospital_id, long doctor_id, string date, string reason, string description)
        {
            var service = BootNinjectConfiguration.Kernel.Get<ISheduledVisitationService>();
            return service.AddNewVisitation(patient_id, hospital_id, doctor_id, date, reason, description);
        }

        #endregion

        #region Rating Services

        public bool RatingHospital(long patient_id, long hospital_id, int rating)
        {
            var service = BootNinjectConfiguration.Kernel.Get<IRatingService>();
            return service.RatingHospital(patient_id, hospital_id, rating);
        }

        public bool RatingDoctor(long patient_id, long doctor_id, int rating)
        {
            var service = BootNinjectConfiguration.Kernel.Get<IRatingService>();
            return service.RatingDoctor(patient_id, doctor_id, rating);
        }
        #endregion

        #region Template Services

        public string GetTemplate(long id)
        {
            var service = BootNinjectConfiguration.Kernel.Get<ITemplateService>();
            return service.GetTemplate(id);
        }

        public string GetAllPatientTemplates(long patient_id)
        {
            var service = BootNinjectConfiguration.Kernel.Get<ITemplateService>();
            return service.GetAllPatientTemplates(patient_id);
        }

        public bool AddTemplate(long patient_id, long hospital_id, long doctor_id, string title, string reason, string description)
        {
            var service = BootNinjectConfiguration.Kernel.Get<ITemplateService>();
            return service.AddTemplate(patient_id, hospital_id, doctor_id, title, reason, description);
        }

        #endregion

        #region Recommended Visitations Services

        public string GetRecommendedVisitation(long id)
        {
            var service = BootNinjectConfiguration.Kernel.Get<IRecommendedVisistationService>();
            return service.GetRecommendedVisitation(id);
        }

        public string GetRecommendedVisitationForPatient(int age)
        {
            var service = BootNinjectConfiguration.Kernel.Get<IRecommendedVisistationService>();
            return service.GetRecommendedVisitationForPatient(age);
        }

        #endregion
    }
}
