﻿using System.Collections.Generic;
using WebUI.Models;

namespace WebUI.ViewModels.Subdivision
{
    public class SubdivisionsListViewModel
    {
        public List<SubdivisionViewModel> Subdivisions { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }
    }
}