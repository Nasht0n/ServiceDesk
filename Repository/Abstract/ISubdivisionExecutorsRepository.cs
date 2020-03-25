using Domain.Models.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface ISubdivisionExecutorsRepository
    {
        Task<SubdivisionExecutor> AddSubdivisionExecutor(SubdivisionExecutor subdivisionExecutor);
        Task DeleteSubdivisionExecutor(SubdivisionExecutor subdivisionExecutor);
        Task<List<SubdivisionExecutor>> GetSubdivisionExecutors();
    }
}
