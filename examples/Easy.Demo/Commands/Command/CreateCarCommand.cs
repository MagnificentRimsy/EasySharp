using Easy.Demo.Models;
using EasySharp.Core.Commands;
using System;
using System.Collections.Generic;

namespace Easy.Demo.Commands.Command
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateCarCommand : ICommand<IEnumerable<CarDto>>
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
