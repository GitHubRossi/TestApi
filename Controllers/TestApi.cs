using Microsoft.AspNetCore.Mvc;
using TestApi.Extensions;
using TestApi.Helpers;
using TestApi.Init;
using TestApi.Models;
using NLog;

namespace TestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestApiController : ControllerBase
{
    private static readonly NLog.ILogger _logger = LogManager.GetCurrentClassLogger();

    private FileStorage _fileStorage;

    public TestApiController(FileStorage fileStorage)
    {
        _fileStorage = fileStorage;
    }

    [HttpPost]
    [Route("DataProviderByInputValue/{key:int}")]

    public ActionResult<ResultModel> DataProviderByInputValue(int key, BodyInput input)
    {
        DateTime callTime = DateTime.Now;

        ResultModel result = new ResultModel();

        var dicVal = DicHelpers.CreateDicVal(2, callTime);

        MemoryStorage.memoryStorageDictionary.TryGetValue(key, out DicVal? previous_value);

        if (previous_value != null) result.Previous_value = previous_value.Value;
        result.Input_value = input.Input;
        result.Computed_value = DicHelpers.GetDicValue(key, input.Input, dicVal, callTime);

        _fileStorage.SaveToFile(result, callTime);

        return Ok(result);
    }
}
