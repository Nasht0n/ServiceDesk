using BusinessLogic.Abstract;
using Domain.Models;
using Domain.Models.ManyToMany;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class SubdivisionExecutorLogic : ISubdivisionExecutorLogic
    {
        private readonly ISubdivisionExecutorsRepository subdivisionExecutorsRepository;

        public SubdivisionExecutorLogic(ISubdivisionExecutorsRepository subdivisionExecutorsRepository)
        {
            this.subdivisionExecutorsRepository = subdivisionExecutorsRepository;
        }
        public async Task<List<SubdivisionExecutor>> GetExecutors(Subdivision subdivision, bool descendings = false)
        {
            var list = await subdivisionExecutorsRepository.GetSubdivisionExecutors();
            if(descendings) return list.Where(se => se.SubdivisionId == subdivision.Id).OrderByDescending(se=>se.SubdivisionId).ToList();
            else return list.Where(se => se.SubdivisionId == subdivision.Id).OrderBy(se=>se.SubdivisionId).ToList();
        }
    }
}
