using TestApi.Models;

namespace TestApi.Extensions;

public static class FileStorage
{
    public static bool SaveToFile(ResultModel resultModel,  DateTime callTime ){
        string docPath =   Environment.CurrentDirectory;

        // Write & append the string array to a new file named "Storage.txt".
        using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "Storage.txt"), true))
        {
            outputFile.WriteLine("PreVal:{0}, NewVal:{1}, Changed:{2}",resultModel.Previous_value.ToString(), resultModel.Computed_value.ToString(), callTime.ToString("MM/dd/yyyy H:mm"));
        }
        return true;
    }
}
