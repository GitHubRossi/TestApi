using System.Collections.Concurrent;
using TestApi.Interfaces;
using TestApi.Models;

namespace TestApi.Init;

public class MemoryStorage : IMemoryStorage
{
public static ConcurrentDictionary<double,DicVal> memoryStorageDictionary = new ConcurrentDictionary<double, DicVal>();

    public DicVal CreateDicVal(decimal val, DateTime callTime)
    {
        DicVal dicVal = new DicVal();
        dicVal.DateTime = callTime;
        dicVal.Value = (double)val;
        return dicVal;
    }
    public double GetDicValue(double key, decimal input, DicVal dicVal, DateTime callTime) => MemoryStorage.memoryStorageDictionary.AddOrUpdate(key, dicVal,
        updateValueFactory: (key, val) =>
        {
            return (val.DateTime < callTime.AddSeconds(-15))
            ? dicVal
            : new DicVal { DateTime = callTime, Value = Math.Pow(Math.Log((double)input / (val.Value != 0 ? val.Value : 1)), 3) };
        }
        ).Value;
}

