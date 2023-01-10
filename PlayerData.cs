using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class PlayerData
{
    public int highScore;

    public PlayerData(Score highScoreText)
    {
        highScore = Convert.ToInt32(highScoreText.scoretext);
    }
}
