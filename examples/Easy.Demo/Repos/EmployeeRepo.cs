using Easy.Demo.Data;
using Easy.Demo.Data.Entity;
using Easy.Demo.Interface;
using EasySharp.EfCore.StoredProcedure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Easy.Demo.Repos
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeRepo : IEmployee
    {
        private DataContext _context;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public EmployeeRepo(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            List<Employee> rows = null;

            await _context.TriggerStoredProc("spEmployees")
                .ExecAsync(async r => rows = await r.ToListAsync<Employee>());

            return rows.AsEnumerable();
        }
    }
}
