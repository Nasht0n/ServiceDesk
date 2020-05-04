using Domain.Models;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IExecutorGroupLogic
    {
        Task<ExecutorGroup> GetExecutorGroup(int id);
    }
}
