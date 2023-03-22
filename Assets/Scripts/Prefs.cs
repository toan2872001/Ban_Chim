using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefs
{
    
    public static int bestScore
    {
        get => PlayerPrefs.GetInt(GameConst.Best_Score, 0);

        set
        {
            int curScore = PlayerPrefs.GetInt(GameConst.Best_Score);
            if(value > curScore)
            {
                PlayerPrefs.SetInt(GameConst.Best_Score, value);
            }
        }
    }
    
}
