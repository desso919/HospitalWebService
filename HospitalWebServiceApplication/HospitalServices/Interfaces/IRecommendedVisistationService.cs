﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServices.Interfaces
{
    public interface IRecommendedVisistationService
    {
        string GetRecommendedVisitation(long id);

        string GetRecommendedVisitationForPatient(int age);
    }
}
