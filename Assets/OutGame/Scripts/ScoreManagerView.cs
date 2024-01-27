using UnityEngine;

public class RankingPanelView : MonoBehaviour
{
    [SerializeField] private Transform contentTransform;
    [SerializeField] private GameObject rankCellPrefab;

    public void UpdateUIWithUserData(ScoreData scoreData)
    {
        for (int i = 0; i < scoreData.userScoreData.Length; i++)
        {
            var dataCell = Instantiate(rankCellPrefab, contentTransform).GetComponent<RankCell>();
            var thisScoreData = scoreData.userScoreData[i];
            dataCell.MakeText(thisScoreData.name, thisScoreData.score.ToString(), Utility.ScoreToRank(thisScoreData.score).ToString());
        }
    }
}
