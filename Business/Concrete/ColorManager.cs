using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult("Color name invalid");
            }
            _colorDal.Add(color);
            return new SuccessResult("Color is added");
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult("Color is deleted.");
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour==14)
            {
                return new ErrorDataResult<List<Color>>("Colors cannot listed");
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),"Colors are listed.");
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>( _colorDal.GetById(co => co.Id == id));
        }

        public IResult Update(Color color)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult("System in maintenance");
            }
            _colorDal.Update(color);
            return new SuccessResult("Car is updated.");
        }
    }
}
