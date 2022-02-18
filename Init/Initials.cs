using System.Collections.Concurrent;
using TestApi.Models;

namespace TestApi.Init;

public class MemoryStorage
{
public static ConcurrentDictionary<double,DicVal> memoryStorageDictionary = new ConcurrentDictionary<double, DicVal>();
}

