using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<Brand> GetById(int brandId);
        IDataResult<List<Brand>> GetList();
        IResult Add(Brand brand);
        IResult Delete(int brandId);
        IResult Update(Brand brand);
    }
}
