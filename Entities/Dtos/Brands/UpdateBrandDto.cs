using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Brands
{
    public class UpdateBrandDto:IDto
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
