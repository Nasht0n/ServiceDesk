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
    public class SubdivisionExecutorLogic : ISubdivisionExecutorLogic
    {
        private readonly ISubdivisionExecutorsRepository subdivisionExecutorsRepository;

        public SubdivisionExecutorLogic(ISubdivisionExecutorsRepository subdivisionExecutorsRepository)
        {
            this.subdivisionExecutorsRepository = subdivisionExecutorsRepository;
        }
        public async Task<List<SubdivisionExecutor>> GetExecutors(int subdivisionId)
        {
            var list = await subdivisionExecutorsRepository.GetSubdivisionExecutors();
            return list.Where(se => se.SubdivisionId == subdivisionId).ToList();
        }
    }
}
