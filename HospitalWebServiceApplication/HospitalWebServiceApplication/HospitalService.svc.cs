﻿using HospitalServices.Interfaces;
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

        public bool AddNewPatient(long id, string gender, string username, string password, string first_name, string second_name, string last_name, string egn, int age, DateTime birth_date)
        {
            throw new NotImplementedException();
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

        public string AddNewHospitalRecord(long id, long patient_id, long hospital_id, long doctor_id, string reason, string diagnose, string date, string description)
        {
            throw new NotImplementedException();
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

        public bool AddNewVisitation(long id, long patient_id, long hospital_id, long doctor_id, string reason, string diagnose, string date, string description)
        {
            var service = BootNinjectConfiguration.Kernel.Get<ISheduledVisitationService>();
            return service.AddNewVisitation(id, patient_id, hospital_id, doctor_id, reason, diagnose, date, description);
        }

        #endregion
    }
}
