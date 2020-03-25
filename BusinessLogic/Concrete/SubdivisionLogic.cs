using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class SubdivisionLogic:ISubdivisionLogic
    {
        private readonly ISubdivisionRepository subdivisionRepository;

        public SubdivisionLogic(ISubdivisionRepository subdivisionRepository)
        {
            this.subdivisionRepository = subdivisionRepository;
        }

        public async Task<Subdivision> GetSubdivision(int id)
        {
            var subdivisions = await subdivisionRepository.GetSubdivisions();
            return subdivisions.FirstOrDefault(s => s.Id == id);
        }
    }
}
