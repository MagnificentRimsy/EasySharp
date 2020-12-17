using Easy.Demo.Models;
using EasySharp.Core.Attributes;
using EasySharp.Core.Messages;
using EasySharp.Core.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Easy.Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        public static string Entity => "Car"; 

        private readonly ILogger<DemoController> _logger;

        public DemoController(ILogger<DemoController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Trim Method
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("CreateRecordTrimBefore")]
        [TrimInput]
        [LowerInput]
        public IActionResult CreateRecordTrimBefore([FromBody] Car dto) 
            => Ok(dto);
        

        /// <summary>
        /// Api Generic Msg - Object
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("CreateRecord")]
        public ApiGenericResponse<Car> CreateRecord([FromBody] Car dto) 
            => ApiGenericMsg.OnEntityCreateSuccess<Car>(dto, Entity);
        

        /// <summary>
        ///  Api Generic Msg - Array Of Object
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("CreateRecordCollection")]
        public ApiGenericResponse<IEnumerable<Car>> CreateRecordCollection([FromBody] IEnumerable<Car> dto) => 
            ApiGenericMsg.OnEntityCreateSuccess<IEnumerable<Car>>(dto, Entity);
    }
}
