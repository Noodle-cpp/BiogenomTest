﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class VitaminAttributeViewModel
    {
        public string VitaminTitle { get; set; }
        public double Value { get; set; }
        public double NormValue { get; set; }
        public double ValueDif { get; set; }
    }
}
