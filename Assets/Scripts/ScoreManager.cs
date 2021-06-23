using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;
    public Player playerHealth;

    private void Update()
    {
        //if (score >= 50)
        //{
        //    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //}

        scoreDisplay.text = "Score: " + score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(playerHealth.health <= 0)
        {
            return;
        }

        if (other.CompareTag("Enemy")){
            score++;
        }
    }
}
