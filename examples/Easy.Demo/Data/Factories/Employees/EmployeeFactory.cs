using Easy.Demo.Models;
using System;
using System.Collections.Generic;

namespace Easy.Demo.Factories.Employees
{
    /// <summary>
    /// create fake cars
    /// </summary>
    public class EmployeeFactory
    {
        /// <summary>
        /// Fake record
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<EmployeeDto> Create()
        {
            var cars = new List<EmployeeDto>();

            cars.Add(new EmployeeDto() { Id = Guid.NewGuid(), FirstName="Michael", LastName = "Asante", Email="asante@gmil.com", Phone="0000000000" });
            cars.Add(new EmployeeDto() { Id = Guid.NewGuid(), FirstName="Issac", LastName = "Ameyaw", Email="killer@gmail.com", Phone="0000000000" });
            cars.Add(new EmployeeDto() { Id = Guid.NewGuid(), FirstName="John", LastName = "Something", Email="coe@gmail.com", Phone="0000000000" });

            return cars;
        }
    }
}
