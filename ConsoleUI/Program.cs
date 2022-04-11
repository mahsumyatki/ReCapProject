using Business.Concrete;
using DataAccess.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Id + " -- " + car.BrandId + " -- " + car.DailyPrice + " -- " + car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}
