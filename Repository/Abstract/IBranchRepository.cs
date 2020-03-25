using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IBranchRepository
    {
        Task<Branch> AddBranch(Branch branch);
        Task<Branch> UpdateBranch(Branch branch);
        Task DeleteBranch(Branch branch);
        Task<List<Branch>> GetBranches();
    }
}
