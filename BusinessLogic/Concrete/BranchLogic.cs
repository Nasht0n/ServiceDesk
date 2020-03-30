using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class BranchLogic : IBranchLogic
    {
        private readonly IBranchRepository branchRepository;

        public BranchLogic(IBranchRepository branchRepository)
        {
            this.branchRepository = branchRepository;
        }

        public async Task<Branch> GetBranchById(int id)
        {
            var branches = await branchRepository.GetBranches();
            return branches.FirstOrDefault(b=>b.Id == id);
        }
    }
}
