using UnityEngine;


public class View : MonoBehaviour
{
    public Logic logic;
    public ScoreData logic_scoreData;

    [SerializeField] private GameObject rankCellPrefab;
    [SerializeField] private Transform canvasTransform;

    // Start is called before the first frame update
    void Start()
    {
        logic.ShowRankingScore();
    }

    public void UpdateUIWithUserData()
    {

        logic_scoreData = logic.scoreData;
        for (int i = 0; i < logic_scoreData.userScoreData.Length; i++)
        {
            var dataCell = Instantiate(rankCellPrefab, canvasTransform).GetComponent<RankCell>();

            RankCell RankCellScript = dataCell.GetComponent<RankCell>();
            RankCellScript.MakeText(logic_scoreData.userScoreData[i].name, logic_scoreData.userScoreData[i].score.ToString(), Utility.ScoreToRank(logic_scoreData.userScoreData[i].score).ToString());
        }
    }
}
