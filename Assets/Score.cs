using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("SavedScore", 0).ToString();
    }

    private void Update()
    {
        scoretext.text = player.position.x.ToString("0");

        SetHighScore();
    }

    void SetHighScore()
    {
        int currentScore = Convert.ToInt32(scoretext.text);

        if (currentScore > PlayerPrefs.GetInt("SavedScore", 0))
        {
            PlayerPrefs.SetInt("SavedScore", currentScore);
            highScoreText.text = currentScore.ToString();
        }
    }
}
