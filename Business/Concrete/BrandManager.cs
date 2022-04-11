﻿using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult("Brand name invalid");
            }
            _brandDal.Add(brand);
            return new SuccessResult("Brand is added");
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult("Brand is deleted.");
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int Id)
        {
            return _brandDal.GetById(b => b.Id == Id);
        }

        public IResult Update(Brand brand)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult("System in maintenance");
            }
            _brandDal.Update(brand);
            return new SuccessResult("Car is updated.");
        }
    }
}
