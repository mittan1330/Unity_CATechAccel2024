using UnityEngine;


public class View : MonoBehaviour
{
    public Logic _logic;
    public ScoreData _logic_scoreData;

    [SerializeField] private GameObject rankCell;
    [SerializeField] private Transform canvasTransform;

    // Start is called before the first frame update
    void Start()
    {
        _logic.ShowRankingScore();
    }

    public void UpdateUIWithUserData()
    {
        for (int i = 0; i < _logic_scoreData.userScoreData.Length; i++)
        {
            var dataCell = Instantiate(rankCell, canvasTransform).GetComponent<RankCell>();

            RankCell RankCellScript = dataCell.GetComponent<RankCell>();
            RankCellScript.MakeText(_logic_scoreData.userScoreData[i].name, _logic_scoreData.userScoreData[i].score.ToString(), Utility.ScoreToRank(_logic_scoreData.userScoreData[i].score).ToString());
        }
    }
}
