using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private static int PlayerScore;

    // Update is called once per frame
    void Update()
    {
        
        PlayerScore = CollisionDetetction.Score;
        scoreText.text = PlayerScore.ToString("0");
    }
}
