using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            System.Console.WriteLine(" Şu anlık Database boş olduğu için sonuç alamıyoruz");
            foreach (var car in carManager.GetAll())
            {
                System.Console.WriteLine("{0} : {1}",car.Description,car.DailyPrice);
            }
        }
    }
}
