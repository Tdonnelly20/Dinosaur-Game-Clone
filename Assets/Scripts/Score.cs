using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI ScoreText, HighScoreText;
    private int _score, _highScore;
    private float _timer;
    private float _maxTime;

    void Start()
    {
        //Resets Score
        _score = 0;
        //Sets _highScore to the saved highscore
        _highScore = PlayerPrefs.GetInt("highscore", 0);
        HighScoreText.text = "High Score: "+_highScore.ToString("00000");
        _maxTime = 0.1f;
    }
    
    void Update()
    {
        //Updates the score
        _timer += Time.deltaTime;
        if (_timer >= _maxTime)
        {
            _score++;
            ScoreText.text = _score.ToString("00000");
            _timer = 0;
        }

        /*
         If the game is over and the score is greater than the previous high score then
         update and save new high score
         */
        if (Time.timeScale == 0)
        {
            if (_score > _highScore)
            {
                _highScore = _score;
                PlayerPrefs.SetInt("highscore",_score);
                HighScoreText.text = "High Score: "+_score.ToString("00000");
            }
        }
    }
}
