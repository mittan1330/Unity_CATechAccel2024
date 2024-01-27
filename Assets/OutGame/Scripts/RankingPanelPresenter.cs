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

public class RankingPanelPresenter : MonoBehaviour
{
    [SerializeField] RankingPanelView _view;
    private RankingPanelModel _model;
    private ScoreData scoreData;

    private void Awake()
    {
        _model = new RankingPanelModel();
    }

    void Start()
    {
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
