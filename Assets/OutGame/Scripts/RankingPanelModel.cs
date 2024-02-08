using System.IO;
using UnityEngine;

public class RankingPanelModel
{

    private ScoreData scoreData;

    public void SetScoreData(ScoreData data)
    {
        scoreData = data;
    }

    public ScoreData GetScoreData()
    {
        return scoreData;
    }
}
