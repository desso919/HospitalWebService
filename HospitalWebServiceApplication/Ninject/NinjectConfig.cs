using HospitalServices.Interfaces;
using HospitalServicesImpl.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninject
{
    public static class NinjectConfig
    {
        public static IKernel Kernel { get; private set; }

        public static void ConfigureContainer()
        {
            Kernel = new StandardKernel();
            Kernel.Bind<IPatientService>().To<PatientService>().InTransientScope();
        }
    }
}
