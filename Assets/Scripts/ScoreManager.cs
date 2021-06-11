using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;
    public Player playerHealth;

    //private void Start()
    //{
    //    playerHealth = GetComponent<Player>();
    //}

    private void Update()
    {
        scoreDisplay.text = "Score: " + score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(playerHealth);
        if(playerHealth.health <= 0)
        {
            return;
        }

        if (other.CompareTag("Enemy")){
            score++;
            //Debug.Log(score);
        }
    }
}
