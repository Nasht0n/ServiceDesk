using BusinessLogic.Abstract;
using Domain.Models;
using Domain.Models.ManyToMany;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class ExecutorGroupMemberLogic : IExecutorGroupMemberLogic
    {
        private readonly IExecutorGroupMembersRepository executorGroupMembersRepository;

        public ExecutorGroupMemberLogic(IExecutorGroupMembersRepository executorGroupMembersRepository)
        {
            this.executorGroupMembersRepository = executorGroupMembersRepository;
        }

        public async Task<List<ExecutorGroupMember>> GetExecutorGroupMembers(ExecutorGroup executorGroup)
        {
            var groupMembers = await executorGroupMembersRepository.GetGroupMembers();
            return groupMembers.Where(gm => gm.ExecutorGroupId == executorGroup.Id).ToList();
        }
    }
}
