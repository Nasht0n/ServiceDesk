﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IServiceLogic
    {
        Task<Service> GetServiceById(int id);
        Task<List<Service>> GetActiveServices();
    }
}
