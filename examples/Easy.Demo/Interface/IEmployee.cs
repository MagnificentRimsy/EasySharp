using Easy.Demo.ProcModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easy.Demo.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEmployee
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Employee>> GetEmployees();
    }
}
