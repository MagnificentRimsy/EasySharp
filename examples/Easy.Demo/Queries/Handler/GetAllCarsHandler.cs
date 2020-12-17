using Easy.Demo.Factories.Cars;
using Easy.Demo.Models;
using Easy.Demo.Queries.Query;
using EasySharp.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Easy.Demo.Queries.Handler
{
    /// <summary>
    /// 
    /// </summary>
    public class GetAllCarsHandler : IQueryHandler<GetAllCarsQuery, IEnumerable<CarDto>>
    {
        /// <summary>
        /// 
        /// </summary>
        public GetAllCarsHandler()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CarDto>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            var result = CarFactory.Create();

            return result;
        }
    }
}
