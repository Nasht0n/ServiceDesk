using BusinessLogic.Abstract;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BranchModel = Domain.Models.Branch;

namespace BusinessLogic.Concrete
{
    public class BranchLogic : IBranchLogic
    {
        private readonly IBranchRepository branchRepository;

        public BranchLogic(IBranchRepository branchRepository)
        {
            this.branchRepository = branchRepository;
        }

        public async Task<BranchModel> GetBranch(int id)
        {
            var branches = await branchRepository.GetBranches();
            return branches.FirstOrDefault(b=>b.Id == id);
        }

        public async Task<List<BranchModel>> GetBranches(bool descendings = false)
        {
            var branches = await branchRepository.GetBranches();
            if(descendings) return branches.OrderByDescending(b => b.Fullname).ToList();
            else return branches.OrderBy(b => b.Fullname).ToList();
        }
    }
}
