﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Categories
{
    public class UpdateCategoryDto:IDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
