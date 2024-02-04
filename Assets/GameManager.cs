using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float GameTime;
    public static bool isTimeStop;

    private void Start()
    {
        isTimeStop = false;
    }
}
