using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    public float Yincrement;

    public float speed;
    public float maxHeight;
    public float minHeight;

    public int health;
    public Text healthDisplay;

    public GameObject gameOver;
    public GameObject effect;
    public GameObject moveUpEffect;
    public GameObject moveDownEffect;

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = "HP: " + health.ToString();

        if(health <= 0)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            gameOver.SetActive(true);
            Destroy(gameObject);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && transform.position.y < maxHeight)
        {
            Instantiate(moveUpEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
        }
        else if((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && transform.position.y > minHeight)
        {
            Instantiate(moveDownEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
        }
    }
}
