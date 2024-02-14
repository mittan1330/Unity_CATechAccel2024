using UnityEngine;
using UnityEngine.Pool;

public class RankingPanelView : MonoBehaviour
{
    [SerializeField] private Transform contentTransform;
    [SerializeField] private GameObject rankCellPrefab;

    private ObjectPool<GameObject> pool;

    private void Start()
    {
        ObjectPool<GameObject> pool = new ObjectPool<GameObject>(
        createFunc: () => GameObject.CreatePrimitive(PrimitiveType.Cube),   
        actionOnGet: target => target.SetActive(true),                            
        actionOnRelease: target => target.SetActive(false),                       
        actionOnDestroy: target => Destroy(target),                               
        collectionCheck: true,                                                    
        defaultCapacity: 10,                                                      
        maxSize: 100);
    }

    public void UpdateUIWithUserData(ScoreData scoreData)
    {
        for (int i = 0; i < scoreData.userScoreData.Length; i++)
        {
            var dataCell = Instantiate(rankCellPrefab, contentTransform).GetComponent<RankCell>();
            var ScoreData = scoreData.userScoreData[i];
            var Score = ScoreData.score;
            dataCell.MakeText(ScoreData.name, Score.ToString(), Utility.ScoreToRank(Score).ToString());
        }
    }
}
