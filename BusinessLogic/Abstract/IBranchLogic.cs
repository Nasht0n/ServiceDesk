using System.Collections.Generic;
using System.Threading.Tasks;
using BranchModel = Domain.Models.Branch;

namespace BusinessLogic.Abstract
{
    public interface IBranchLogic
    {
        Task<List<BranchModel>> GetBranches(bool descendings = false);
        Task<BranchModel> GetBranch(int id);
    }
}
