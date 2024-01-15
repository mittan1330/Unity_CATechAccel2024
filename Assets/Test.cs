using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private int dataCount = 10;
    [SerializeField] private GameObject rankCellPrefab;
    [SerializeField] private Transform canvasTransform;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < dataCount; i++)
        {
            var dataCell = Instantiate(rankCellPrefab,canvasTransform).GetComponent<RankCell>();
            dataCell.userName.text = "";
            dataCell.score.text = "1000";
            dataCell.rank.text = "B";
        }
    }

    
}
