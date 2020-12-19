using Easy.Demo.Commands.Command;
using Easy.Demo.Factories.Cars;
using Easy.Demo.Models;
using EasySharp.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Easy.Demo.Commands.Handler
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateCarHandler : ICommandHandler<CreateCarCommand, CarDto>
    {
        /// <summary>
        /// 
        /// </summary>
        public CreateCarHandler()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CarDto> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            //make db call rather
            var result = CarFactory.Create();

            return result.FirstOrDefault();
        }
    }
}
