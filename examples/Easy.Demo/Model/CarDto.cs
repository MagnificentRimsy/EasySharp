using EasySharp.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easy.Demo.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class CarDto : IEntity
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}
