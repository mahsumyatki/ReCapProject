using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>();
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            _carImageDal.GetAll(ci=>ci.CarId==carId);
            return new SuccessDataResult<List<CarImage>>();
        }

        public IDataResult<CarImage> GetById(int id)
        {
            _carImageDal.GetById(ci=>ci.Id==id);
            return new SuccessDataResult<CarImage>();
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
    }
}
