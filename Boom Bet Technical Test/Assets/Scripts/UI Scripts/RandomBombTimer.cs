using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBombTimer : MonoBehaviour
{
    private int maxRangeTimer = 11;
    private int minRangeTimer = 1;
    public static int bombTimerResult;
    void Awake()
    {
        bombTimerResult = Random.Range(minRangeTimer, maxRangeTimer);   
    }
}
