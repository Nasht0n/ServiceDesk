using Domain.Models.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IExecutorGroupMembersRepository
    {
        Task<ExecutorGroupMember> AddExecutorGroupMember(ExecutorGroupMember member);
        Task DeleteExecutorGroupMember(ExecutorGroupMember member);
        Task<List<ExecutorGroupMember>> GetGroupMembers();
    }
}
