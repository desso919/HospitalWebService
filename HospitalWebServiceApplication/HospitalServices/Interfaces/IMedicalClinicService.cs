﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServices.Interfaces
{
    public interface IMedicalClinicService
    {
        string GetHospital(long hospital_id);

        string GetAllHospitals();
    }
}
