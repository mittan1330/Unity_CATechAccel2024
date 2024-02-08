using System.IO;
using UnityEngine;


[System.Serializable]
public class ScoreData
{
    public DataClass[] userScoreData;
}

[System.Serializable]
public class DataClass
{
    public string name;
    public int score;
    public string rank;
}

public class Logic
{
    public View view;
    public ScoreData scoreData;

    public void ShowRankingScore()
    {
        string jsonFilePath = Application.dataPath + "/OutGame/Scripts/score.json";

        if (File.Exists(jsonFilePath))
        {
            string jsonContent = File.ReadAllText(jsonFilePath);

            scoreData = JsonUtility.FromJson<ScoreData>("{\"userScoreData\":" + jsonContent + "}");

            view.UpdateUIWithUserData();
        }
        else
        {
            Debug.LogError("Json file not found at path: " + jsonFilePath);
        }
    }

    
}
