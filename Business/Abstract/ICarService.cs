using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        List<Car> GetAll();
        Car GetById(int Id);
        List<CarDetailDto> GetCarDetails();
        List<Car> GetByBrandId(int brandId);
        List<Car> GetByColorId(int colorId);
    }
}
