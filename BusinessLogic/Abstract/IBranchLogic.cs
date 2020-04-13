using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BranchModel = Domain.Models.Branch;

namespace BusinessLogic.Abstract
{
    public interface IBranchLogic
    {
        Task<List<BranchModel>> GetBranches();
        Task<BranchModel> GetBranchById(int id);
    }
}
