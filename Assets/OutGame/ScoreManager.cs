using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataClass
{
    public string name;
    public string score;
    public string rank;
}

public class ScoreManager : MonoBehaviour
{
    public DataClass[] userScoreData;
    public RankCell[] rankCells;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < rankCells.Length; i++)
        {
            RankCell RankCellScript = rankCells[i].GetComponent<RankCell>();
            RankCellScript.MakeText(userScoreData[i].name, userScoreData[i].score, userScoreData[i].rank);
        }
    }
}