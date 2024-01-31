using System.IO;
using UnityEngine;

public class RankingPanelModel
{
    public string GetJsonFile(string path)
    {
        if (File.Exists(path))
        {
            return File.ReadAllText(path);
        }
        else
        {
            Debug.LogError("Json file not found at path: " + path);
            return string.Empty; // または適切なデフォルト値を返す
        }
    }
}
