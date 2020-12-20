using Easy.Demo.Data.Entity;
using Easy.Demo.Interface;
using Easy.Demo.Queries.Query;
using EasySharp.Core.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Easy.Demo.Queries.Handler
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAllEmployeesHandler : IQueryHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
    {
        private readonly IEmployee _employee;

        /// <summary>
        /// 
        /// </summary>
        public GetAllEmployeesHandler(IEmployee employee)
        {
            _employee = employee;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var result =  await _employee.GetEmployees();

            return result;
        }
    }
}
