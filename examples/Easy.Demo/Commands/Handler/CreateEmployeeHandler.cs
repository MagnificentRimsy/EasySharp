using Easy.Demo.Commands.Command;
using Easy.Demo.Factories.Employees;
using Easy.Demo.Models;
using EasySharp.Core.Commands;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Easy.Demo.Commands.Handler
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateEmployeeHandler : ICommandHandler<CreateEmployeeCommand, EmployeeDto>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateEmployeeHandler()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            //make db call rather
            var result = EmployeeFactory.Create();
                    
            return result.FirstOrDefault();
        }
    }
}
