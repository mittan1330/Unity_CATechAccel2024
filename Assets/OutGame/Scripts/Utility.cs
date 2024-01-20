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

    public static Utility.Rank ScoreToRank(int score)
    {
        switch (score)
        {
            case < 10:
                return Rank.D;
            case < 20:
                return Rank.C;
            case < 40:
                return Rank.B;
            case < 70:
                return Rank.A;
            default:
                return Rank.Error;
        }

    }
}
