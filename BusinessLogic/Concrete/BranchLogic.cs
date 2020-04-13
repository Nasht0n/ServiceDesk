using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<BranchModel> GetBranchById(int id)
        {
            var branches = await branchRepository.GetBranches();
            return branches.FirstOrDefault(b=>b.Id == id);
        }

        public async Task<List<BranchModel>> GetBranches()
        {
            var branches = await branchRepository.GetBranches();
            return branches.OrderBy(b => b.Id).ToList();
        }
    }
}
