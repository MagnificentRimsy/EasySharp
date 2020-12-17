using Easy.Demo.Models;
using System.Collections.Generic;

namespace Easy.Demo.Factories.Cars
{
    /// <summary>
    /// create fake cars
    /// </summary>
    public class CarFactory
    {
        /// <summary>
        /// Fake record
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<CarDto> Create()
        {
            var cars = new List<CarDto>();

            cars.Add(new CarDto() { Brand = "BMW", Model = "3-Series", Year = 2012 });
            cars.Add(new CarDto() { Brand = "BMW", Model = "5-Series", Year = 2017 });
            cars.Add(new CarDto() { Brand = "Mercedes-Benz", Model = "CLA 63", Year = 2016 });

            return cars;
        }
    }
}
