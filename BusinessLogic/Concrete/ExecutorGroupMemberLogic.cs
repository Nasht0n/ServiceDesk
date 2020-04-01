using BusinessLogic.Abstract;
using Domain.Models.ManyToMany;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<List<ExecutorGroupMember>> GetExecutorGroupMembers(int executorGroupId)
        {
            var groupMembers = await executorGroupMembersRepository.GetGroupMembers();
            return groupMembers.Where(gm => gm.ExecutorGroupId == executorGroupId).ToList();
        }
    }
}
