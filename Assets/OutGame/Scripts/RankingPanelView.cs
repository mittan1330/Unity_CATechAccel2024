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
        createFunc: () => GameObject.CreatePrimitive(PrimitiveType.Cube),         // プールが空のときに新しいインスタンスを生成する処理
        actionOnGet: target => target.SetActive(true),                            // プールから取り出されたときの処理 
        actionOnRelease: target => target.SetActive(false),                       // プールに戻したときの処理
        actionOnDestroy: target => Destroy(target),                               // プールがmaxSizeを超えたときの処理
        collectionCheck: true,                                                    // 同一インスタンスが登録されていないかチェックするかどうか
        defaultCapacity: 10,                                                      // デフォルトの容量
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
