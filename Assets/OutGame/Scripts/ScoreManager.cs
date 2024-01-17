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
    public ScoreData scoreData;
    public RankCell[] rankCells;

    [SerializeField] private GameObject rankCellPrefab;
    [SerializeField] private Transform canvasTransform;

    // Start is called before the first frame update
    void Start()
    {
        ShowRankingScore();
    }

    void UpdateUIWithUserData()
    {
        for (int i = 0; i < scoreData.userScoreData.Length; i++)
        {
            var dataCell = Instantiate(rankCellPrefab, canvasTransform).GetComponent<RankCell>();

            dataCell.userName.text = scoreData.userScoreData[i].name;
            dataCell.score.text = scoreData.userScoreData[i].score.ToString();
            dataCell.rank.text = Utility.ScoreToRank(scoreData.userScoreData[i].score);
        }
    }

    void ShowRankingScore()
    {
        string jsonFilePath = Application.dataPath + "/OutGame/Scripts/score.json";

        if (File.Exists(jsonFilePath))
        {
            string jsonContent = File.ReadAllText(jsonFilePath);

            scoreData = JsonUtility.FromJson<ScoreData>("{\"userScoreData\":" + jsonContent + "}");

            UpdateUIWithUserData();
        }
        else
        {
            Debug.LogError("Json file not found at path: " + jsonFilePath);
        }
    }
}
