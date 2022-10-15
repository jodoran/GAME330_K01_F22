using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public Text scoreText;
    int score = 0;

    void Scorer()
    {
        if(Enemy.enemyDied == true)
        {
            score += 1;
            scoreText.text = "Score: " + score.ToString();
            Enemy.enemyDied = false;
        }
    }

    private void Update()
    {
        Scorer();
    }
}
