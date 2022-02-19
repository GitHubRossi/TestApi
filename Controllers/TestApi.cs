using Microsoft.AspNetCore.Mvc;
using TestApi.Init;
using TestApi.Models;
using NLog;
using System;
using TestApi.Interfaces;
using System.Net;

namespace TestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestApiController : ControllerBase
{
    private static readonly NLog.ILogger _logger = LogManager.GetCurrentClassLogger();

    private IFileStorage _fileStorage { get; set; }
    private IMemoryStorage _memoryStorage { get; set; }

    public TestApiController(IFileStorage fileStorage, IMemoryStorage memoryStorage)
    {
        _memoryStorage = memoryStorage;
        _fileStorage = fileStorage;
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [Route("Calculation/{key:int}")]

    public ActionResult<ResultModel> Calculation(int key, BodyInput input)
    {
        try
        {
            DateTime callTime = DateTime.Now;

            ResultModel result = new ResultModel();

            var dicVal = _memoryStorage.CreateDicVal(2, callTime);

            MemoryStorage.memoryStorageDictionary.TryGetValue(key, out DicVal? previous_value);

            if (previous_value != null) result.Previous_value = previous_value.Value;
            result.Input_value = input.Input;
            result.Computed_value = _memoryStorage.GetDicValue(key, input.Input, dicVal, callTime);

            _fileStorage.SaveToFile(result, callTime);

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.Error($"Unknown error ex={ex.InnerException}");
            return BadRequest();
        }
    }
}
