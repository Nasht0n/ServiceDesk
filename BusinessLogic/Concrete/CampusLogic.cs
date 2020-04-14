﻿using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class CampusLogic : ICampusLogic
    {
        private readonly ICampusRepository campusRepository;

        public CampusLogic(ICampusRepository campusRepository)
        {
            this.campusRepository = campusRepository;
        }

        public async Task<Campus> GetCampusById(int id)
        {
            var campuses = await campusRepository.GetCampuses();
            return campuses.FirstOrDefault(c => c.Id == id);
        }

        public async Task<List<Campus>> GetCampuses()
        {
            var campuses = await campusRepository.GetCampuses();
            return campuses.OrderBy(c=>c.Id).ToList();
        }

        public async Task<List<Campus>> GetCampusesDescending()
        {
            var campuses = await campusRepository.GetCampuses();
            return campuses.OrderByDescending(c => c.Id).ToList();
        }
    }
}