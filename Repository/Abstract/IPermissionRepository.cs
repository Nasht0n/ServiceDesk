﻿using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IPermissionRepository
    {
        Task<List<Permission>> GetPermissions();
    }
}