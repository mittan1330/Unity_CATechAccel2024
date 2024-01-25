using UnityEngine;

public class ScoreManagerView : MonoBehaviour
{
    public RankCell[] rankCells;

    [SerializeField] private Transform canvasTransform;
    [SerializeField] private GameObject rankCellPrefab;

    public void UpdateUIWithUserData(ScoreData scoreData)
    {
        for (int i = 0; i < scoreData.userScoreData.Length; i++)
        {
            var dataCell = Instantiate(rankCellPrefab, canvasTransform).GetComponent<RankCell>();
            RankCell RankCellScript = dataCell.GetComponent<RankCell>();
            RankCellScript.MakeText(scoreData.userScoreData[i].name, scoreData.userScoreData[i].score.ToString(), Utility.ScoreToRank(scoreData.userScoreData[i].score).ToString());
        }
    }
}
