using System.Collections;
using System.Collections.Generic;
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

public class ScoreManager : MonoBehaviour
{
    [SerializeField] ScoreManagerView _view;
    [SerializeField] ScoreManagerModel _model;
    private ScoreData scoreData;

    // Start is called before the first frame update
    void Start()
    {
        _model = new ScoreManagerModel();
        ShowRankingScore();
    }

    void ShowRankingScore()
    {
        string jsonFilePath = Application.dataPath + "/OutGame/Scripts/score.json";

        if (File.Exists(jsonFilePath))
        {
            string jsonContent = _model.GetJsonFile(jsonFilePath);

            if (jsonContent != null) scoreData = JsonUtility.FromJson<ScoreData>("{\"userScoreData\":" + jsonContent + "}");

            _view.UpdateUIWithUserData(scoreData);
        }
        else
        {
            Debug.LogError("Json file not found at path: " + jsonFilePath);
        }
    }
}
