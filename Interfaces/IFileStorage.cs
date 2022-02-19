using System;
using TestApi.Models;

namespace TestApi.Interfaces;

public interface IFileStorage
{
    public void SaveToFile(ResultModel resultModel, DateTime callTime);
}
