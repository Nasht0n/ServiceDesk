using DataAccess.Concrete;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class BranchService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

        public List<Branch> GetBranches()
        {
            return serviceDesk.BranchRepository.Get().ToList();
        }

        public Branch GetBranchById(int id)
        {
            return serviceDesk.BranchRepository.Get(filter: e => e.Id == id).FirstOrDefault();
        }

        public void AddBranch(Branch branch)
        {
            serviceDesk.BranchRepository.Insert(branch);
            serviceDesk.Save();
        }

        public void UpdateBranch(Branch branch)
        {
            serviceDesk.BranchRepository.Update(branch);
            serviceDesk.Save();
        }

        public void DeleteBranch(Branch branch)
        {
            serviceDesk.BranchRepository.Delete(branch);
            serviceDesk.Save();
        }
    }
}
