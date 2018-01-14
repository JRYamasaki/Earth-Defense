using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour 
{
    public GUIText scoreText;
    private int score;

	void Start () 
    {
        score = 0;
        scoreText.text = "SCORE: 0";	
	}

    public void AddScore(int alienScoreValue)
    {
        score += alienScoreValue;
        UpdateScore();
    }

    public void UpdateScore ()
    {
        scoreText.text = "SCORE: " + score;
    }
}
