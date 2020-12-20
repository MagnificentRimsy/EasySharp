using Easy.Demo.Models;
using EasySharp.Core.Commands;
using System;
using System.Collections.Generic;

namespace Easy.Demo.Commands.Command
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateEmployeeCommand : ICommand<EmployeeDto>
    {
        public string FirstName { get; set; }
        public int LastName { get; set; } 
        public int Email { get; set; }
        public int Phone { get; set; }
    }
}
