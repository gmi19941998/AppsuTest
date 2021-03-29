
using UnityEngine;

public class ScoreCount : ICounter<int>
{
    public int Value
    {
        get => PlayerPrefs.GetInt("Score", 0);
        set => PlayerPrefs.SetInt("Score",value);
    }
}
