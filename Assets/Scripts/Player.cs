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
    //public Text healthDisplay;
    public int numOfLights;
    float phase = 1.0f;

    public Slider phaseSlider;

    public Image[] lights;
    public Sprite fullLight;
    public Sprite emptyLight;

    public GameObject gameOver;
    public GameObject effect;
    public GameObject moveUpEffect;
    public GameObject moveDownEffect;

    SpriteRenderer colorHolder;
    BoxCollider2D playerTrigger;

    private void Start()
    {
        colorHolder = GetComponent<SpriteRenderer>();
        playerTrigger = GetComponent<BoxCollider2D>();
        phaseSlider.value = phase;
    }

    void ManageHealth()
    {
        if (health > numOfLights)
        {
            health = numOfLights;
        }

        //healthDisplay.text = "HP: " + health.ToString();
        for (int i = 0; i < lights.Length; i++)
        {
            if (i < health)
            {
                lights[i].sprite = fullLight;
            }
            else
            {
                lights[i].sprite = emptyLight;
            }


            if (i < numOfLights)
            {
                lights[i].enabled = true;
            }
            else
            {
                lights[i].enabled = false;
            }
        }

        if (health <= 0)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            gameOver.SetActive(true);
            Destroy(gameObject);
        }
    }

    void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && transform.position.y < maxHeight)
        {
            Instantiate(moveUpEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
        }
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && transform.position.y > minHeight)
        {
            Instantiate(moveDownEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ManageHealth();
        Movement();

        if(Input.GetKey(KeyCode.Space) && phaseSlider.value > 0)
        {
            colorHolder.color = new Color(1f, 1f, 1f, 0.5f);
            phaseSlider.value -= 1f * Time.deltaTime;
            playerTrigger.isTrigger = false;
        }
        else
        {
            colorHolder.color = new Color(1f, 1f, 1f, 1f);
            phaseSlider.value += 1f * Time.deltaTime;
            playerTrigger.isTrigger = true;
        }
    }
}
