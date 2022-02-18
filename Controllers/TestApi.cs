using Microsoft.AspNetCore.Mvc;
using TestApi.Extensions;
using TestApi.Helpers;
using TestApi.Init;
using TestApi.Models;


namespace TestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestApiController : ControllerBase
{
    private readonly ILogger<TestApiController> _logger;
 
    public TestApiController(ILogger<TestApiController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    [Route("{key:int}")]

    public ActionResult<ResultModel> DataProviderByInputValue(int key, BodyInput input)
    {
        DateTime callTime = DateTime.Now;
        DicVal? previous_value = null;
        ResultModel result = new ResultModel();

        var dicVal = DicHelpers.CreateDicVal(2, callTime);

        MemoryStorage.memoryStorageDictionary.TryGetValue(key, out previous_value);

        if (previous_value != null) result.Previous_value = previous_value.Value;
        result.Input_value = input.Input;
        result.Computed_value = DicHelpers.GetDicValue(key, input.Input, dicVal, callTime);

        FileStorage.SaveToFile(result, callTime);

        return Ok(result);
    }
}
