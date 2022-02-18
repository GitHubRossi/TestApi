using FluentValidation;
using TestApi.Init;
using TestApi.Models;

namespace TestApi.Helpers;

public class DicHelpers
{
    public static DicVal CreateDicVal (decimal val, DateTime callTime){
        DicVal dicVal = new DicVal();
        dicVal.DateTime = callTime;
        dicVal.Value = (double)val;
        return dicVal;
    }
    public static double GetDicValue(double key, decimal input, DicVal dicVal, DateTime callTime) => MemoryStorage.memoryStorageDictionary.AddOrUpdate(key, dicVal,
        updateValueFactory: (key, val) =>
        {
            return (val.DateTime < callTime.AddSeconds(-15))
            ? dicVal
            : new DicVal { DateTime = callTime, Value = Math.Pow(Math.Log((double)input / (val.Value != 0 ? val.Value : 1)), 3)};
        }
        ).Value;
}

