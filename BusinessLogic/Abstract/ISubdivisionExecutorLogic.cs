using Domain.Models;
using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ISubdivisionExecutorLogic
    {
        Task<List<SubdivisionExecutor>> GetExecutors(Subdivision subdivision, bool descendings = false);
    }
}
