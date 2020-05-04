using Domain.Models;
using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IExecutorGroupMemberLogic
    {
        Task<List<ExecutorGroupMember>> GetExecutorGroupMembers(ExecutorGroup executorGroup);
    }
}
