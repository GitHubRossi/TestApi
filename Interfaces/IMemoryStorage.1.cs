using System;
using TestApi.Models;

namespace TestApi.Interfaces;

public interface IMemoryStorage
{
    DicVal CreateDicVal(decimal val, DateTime callTime);
    double GetDicValue(double key, decimal input, DicVal dicVal, DateTime callTime);
}
