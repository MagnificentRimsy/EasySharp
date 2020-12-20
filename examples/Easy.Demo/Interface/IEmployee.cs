using Easy.Demo.Data.Entity;
using System.Collections.Generic;
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
