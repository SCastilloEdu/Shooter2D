using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour // Score
{
	public static int scoreValue = 0;
	public Text scoreText;
	Text score;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreValue;
    }
}
