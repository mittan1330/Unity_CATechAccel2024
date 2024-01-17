using UnityEngine;

public class Utility : MonoBehaviour
{
    public enum Rank
    {
        Error,
        D,
        C,
        B,
        A,
        S
    }

    public static string ScoreToRank(int number)
    {
        switch (number)
        {
            case < 10:
                return Rank.D.ToString();
            case < 20:
                return Rank.C.ToString();
            case < 40:
                return Rank.B.ToString();
            case < 70:
                return Rank.A.ToString();
            default:
                return Rank.Error.ToString();
        }

    }
}
