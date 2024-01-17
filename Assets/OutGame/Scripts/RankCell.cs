using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankCell : MonoBehaviour
{
    public TextMeshProUGUI userName;
    public TextMeshProUGUI score;
    public TextMeshProUGUI rank;

    public void MakeText(string receivedName, string receivedScore, string receivedRank)
    {
        userName.text = receivedName;
        score.text = receivedScore;
        rank.text = receivedRank;
    }
}