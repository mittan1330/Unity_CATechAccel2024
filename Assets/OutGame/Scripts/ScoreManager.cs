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
    public string score;
    public string rank;
}

public class Utility : MonoBehaviour
{
    public enum Rank
    {
        Error,
        D,
        C,
        B,
        A,
        S
    }

    public static string ScoreToRank(string number)
    {
        if (int.TryParse(number, out int dataScore))
        {
            switch (dataScore)
            {
                case < 10:
                    return Rank.D.ToString();
                case < 20:
                    return Rank.C.ToString();
                case < 40:
                    return Rank.B.ToString();
                case < 70:
                    return Rank.A.ToString();
                default:
                    return Rank.Error.ToString();
            }
        }
        else
        {
            return "Error";
        }
    }
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
            dataCell.score.text = scoreData.userScoreData[i].score;
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
