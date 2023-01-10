using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEventManager
{
    public delegate void GameEvent();

    public static event GameEvent GameStart, GameOver;

    public static void TriggerGameStart()
    {
        if(GameStart != null)
        {
            GameStart();
        }
    }

    public static void TriggerGameOver()
    {
        if(GameOver != null)
        {
            GameOver();
        }
    }
}
