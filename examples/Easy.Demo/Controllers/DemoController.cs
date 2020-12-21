using Easy.Demo.Commands.Command;
using Easy.Demo.Factories.Employees;
using Easy.Demo.Models;
using Easy.Demo.Queries.Query;
using EasySharp.Cache.Store.LocalStorage;
using EasySharp.Cache.Store.Redis;
using EasySharp.Core.Attributes;
using EasySharp.Core.Commands;
using EasySharp.Core.Messages;
using EasySharp.Core.Messages.Response;
using EasySharp.Core.Queries;
using EasySharp.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Easy.Demo.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public static string EntityName => "Employee";

        private readonly IQueryBus _queryBus;
        private readonly ICommandBus _commandBus;

        private readonly IRedisCacheService _redisCacheService;
        private readonly IStorage _storage;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryBus"></param>
        /// <param name="commandBus"></param>
        /// <param name="redisCacheService"></param>
        /// <param name="storage"></param>
        public DemoController(IQueryBus queryBus, ICommandBus commandBus, IRedisCacheService redisCacheService, IStorage storage)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
            _redisCacheService = redisCacheService;
            _storage = storage;
        }


        [HttpGet("LocalStorageDocs")]
        public async Task<IEnumerable<EmployeeDto>> LocalStorageDocs()
        {
            var collection = EmployeeFactory.Create();

            //_storage.DestroyAsync();
            //_storage.ClearAsync();

            var key = Guid.NewGuid().ToString();

            var expected_amount = collection.Count();

            _storage.StoreAsync(key, collection);

            _storage.PersistAsync();

            var target = await _storage.QueryAsync<EmployeeDto>(key);

            return target;
        }

        /// <summary>
        /// Query - CRQS
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCars")]
        public async Task<IActionResult> GetCars(CancellationToken cancellationToken)
        {
            var query = new GetAllEmployeesQuery { };

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
        public IActionResult CreateRecordTrimBefore([FromBody] EmployeeDto dto)
            => Ok(dto);


        /// <summary>
        /// Api Generic Msg - Object
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("CreateRecord")]
        public ApiGenericResponse<EmployeeDto> CreateRecord([FromBody] EmployeeDto dto)
            => ApiGenericMsg.OnEntityCreateSuccess(dto, EntityName);


        /// <summary>
        ///  Api Generic Msg - Array Of Object
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("CreateRecordCollection")]
        public ApiGenericResponse<IEnumerable<EmployeeDto>> CreateRecordCollection([FromBody] IEnumerable<EmployeeDto> dto) =>
            ApiGenericMsg.OnEntityCreateSuccess(dto, EntityName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("CreateCarRecord")]
        public async Task<ApiGenericResponse<EmployeeDto>> CreateCarRecord([FromBody] EmployeeDto dto, CancellationToken cancellationToken)
        {
            //dto -> to -> command type
            var command = Mapping.onMap<EmployeeDto, CreateEmployeeCommand>(dto);

            var result = await _commandBus.Send(command, cancellationToken);

            return ApiGenericMsg.OnEntityCreateSuccess(result, EntityName);
        }
    }
}
