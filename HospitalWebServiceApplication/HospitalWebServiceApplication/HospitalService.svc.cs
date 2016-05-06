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
    }
}
