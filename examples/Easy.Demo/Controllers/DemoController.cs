using Easy.Demo.Commands.Command;
using Easy.Demo.Models;
using Easy.Demo.Queries.Query;
using EasySharp.Core.Attributes;
using EasySharp.Core.Commands;
using EasySharp.Core.Helpers;
using EasySharp.Core.Messages;
using EasySharp.Core.Messages.Response;
using EasySharp.Core.Queries;
using EasySharp.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Easy.Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        public static string EntityName => "Car";

        private readonly IQueryBus _queryBus;
        private readonly ICommandBus _commandBus;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryBus"></param>
        /// <param name="commandBus"></param>
        public DemoController(IQueryBus queryBus, ICommandBus commandBus)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
        }

        /// <summary>
        /// Query - CRQS
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCars")]
        public async Task<IActionResult> GetCars(CancellationToken cancellationToken)
        {
            var query = new GetAllCarsQuery{};

            var result = await _queryBus.Send(query, cancellationToken);

            return Ok(result);

        }

        /// <summary>
        /// Trim Method
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("CreateRecordTrimBefore")]
        [TrimInput]
        [LowerInput]
        public IActionResult CreateRecordTrimBefore([FromBody] CarDto dto) 
            => Ok(dto);
        

        /// <summary>
        /// Api Generic Msg - Object
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("CreateRecord")]
        public ApiGenericResponse<CarDto> CreateRecord([FromBody] CarDto dto) 
            => ApiGenericMsg.OnEntityCreateSuccess(dto, EntityName);
        

        /// <summary>
        ///  Api Generic Msg - Array Of Object
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("CreateRecordCollection")]
        public ApiGenericResponse<IEnumerable<CarDto>> CreateRecordCollection([FromBody] IEnumerable<CarDto> dto) => 
            ApiGenericMsg.OnEntityCreateSuccess(dto, EntityName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("CreateCarRecord")]
        public async Task<ApiGenericResponse<IEnumerable<CarDto>>> CreateCarRecord([FromBody] IEnumerable<CarDto> dto, CancellationToken cancellationToken)
        {
            //dto -> to -> command type
            var command = Mapping.onMap<IEnumerable<CarDto>, CreateCarCommand>(dto);

            var result = await _commandBus.Send(command, cancellationToken);

            return ApiGenericMsg.OnEntityCreateSuccess(result, EntityName);
        }
    }
}
