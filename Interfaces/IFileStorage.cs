using TestApi.Models;

namespace TestApi.Interfaces;

public interface IFileStorage
{
    void SaveToFile(ResultModel resultModel, DateTime callTime);
}
