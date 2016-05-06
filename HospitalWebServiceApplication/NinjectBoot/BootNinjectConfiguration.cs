using HospitalServices.Interfaces;
using HospitalServicesImpl.Implementation;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectBoot
{
    public static class BootNinjectConfiguration
    {
        public static IKernel Kernel { get; private set; }

        public static void ConfigureContainer()
        {
            Kernel = new StandardKernel();
            Kernel.Bind<IPatientService>().To<PatientService>().InTransientScope();
            Kernel.Bind<IMedicalClinicService>().To<MedicalClinicService>().InTransientScope();
            Kernel.Bind<IDoctorService>().To<DoctorService>().InTransientScope();
            Kernel.Bind<IAllergyService>().To<AllergyService>().InTransientScope();
            Kernel.Bind<IPatientHistoryService>().To<PatientHistoryService>().InTransientScope();
            Kernel.Bind<ISheduledVisitationService>().To<SheduledVisitationService>().InTransientScope();
        }
    }
}
