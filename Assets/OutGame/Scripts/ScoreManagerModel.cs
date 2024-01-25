using System.IO;
using UnityEngine;

public class ScoreManagerModel
{
    public string GetJsonFile(string path)
    {
        return File.ReadAllText(path);    
    }
}
