using HospitalServices.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HospitalWebServiceApplication
{
    public class HospitalService : IHospitalService
    {

        #region Patient Service 
       
        public string GetPatient(long id)
        {
            NinjectConfig.ConfigureContainer();
            var service = NinjectConfig.Kernel.Get<IPatientService>();
            return service.GetPatient(id);
        }

        public string GetPatientByUsernameAndPassword(string username, string password)
        {
            throw new NotImplementedException();
        }

        public string GetPatientByEGNAndPassword(string egn, string password)
        {
            throw new NotImplementedException();
        }

        public bool AddNewPatient(long id, string gender, string username, string password, string first_name, string second_name, string last_name, string egn, int age, DateTime birth_date)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
