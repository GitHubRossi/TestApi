using NLog;
using TestApi.Interfaces;
using TestApi.Models;

namespace TestApi.Extensions;

public class FileStorage : IFileStorage
{
    private static readonly NLog.ILogger _logger = LogManager.GetCurrentClassLogger();
    public async void SaveToFile(ResultModel resultModel, DateTime callTime)
    {
        try
        {
            string docPath = Environment.CurrentDirectory;

            // Write & append the string array to a new file named "Storage.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Storage.txt"), true))
            {
                await outputFile.WriteLineAsync($"PreVal:{resultModel.Previous_value.ToString()}, NewVal:{resultModel.Computed_value.ToString()}, Changed:{callTime.ToString("MM/dd/yyyy H:mm")}");
            }
        }
        catch (Exception)
        {
            _logger.Error("FileStorage error");
            throw;
        }
    }
}
