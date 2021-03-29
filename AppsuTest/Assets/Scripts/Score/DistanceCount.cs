using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCount : ICounter<float>
{
    // Start is called before the first frame update
    public float Value
    {
        get => PlayerPrefs.GetFloat("Distance", 0);
        set => PlayerPrefs.SetFloat("Distance",value);
    }
    
}
