using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class ExecutorGroupLogic : IExecutorGroupLogic
    {
        private readonly IExecutorGroupRepository executorGroupRepository;

        public ExecutorGroupLogic(IExecutorGroupRepository executorGroupRepository)
        {
            this.executorGroupRepository = executorGroupRepository;
        }
        public async Task<ExecutorGroup> GetExecutorGroup(int id)
        {
            var executorGroups = await executorGroupRepository.GetExecutorGroups();
            return executorGroups.FirstOrDefault(eg => eg.Id == id);
        }
    }
}
