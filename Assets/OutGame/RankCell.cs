using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RankCell : MonoBehaviour
{
    public TextMeshProUGUI userName;
    public TextMeshProUGUI score;
    public TextMeshProUGUI rank;

    public void MakeText(string name, string s, string r)
    {
        userName.text = name;
        score.text = s;
        rank.text = r;
    }
}