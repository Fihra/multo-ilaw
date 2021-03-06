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
    bool phaseCooldown = false;

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

    private IEnumerator PhaseRoutine()
    {
        colorHolder.color = new Color(1f, 1f, 1f, 1f);
        phaseSlider.value += 0.5f * Time.deltaTime;
        playerTrigger.isTrigger = true;
        yield return new WaitForSeconds(3);
    }

    void Phase()
    {
        if (phaseSlider.value == 1)
        {
            phaseCooldown = false;
        }

        if (phaseSlider.value <= 0)
        {
            phaseCooldown = true;
            StartCoroutine(PhaseRoutine());
        }

        if (Input.GetKey(KeyCode.Space) && phaseSlider.value > 0 && !phaseCooldown)
        {
            colorHolder.color = new Color(1f, 1f, 1f, 0.5f);
            phaseSlider.value -= 1f * Time.deltaTime;
            playerTrigger.isTrigger = false;
        }

        else if (phaseSlider.value < 1f)
        {
            colorHolder.color = new Color(1f, 1f, 1f, 1f);
            phaseSlider.value += 0.5f * Time.deltaTime;
            playerTrigger.isTrigger = true;
        }
        else
        {
            phaseCooldown = true;
        }
    }

    void Update()
    {
        ManageHealth();
        Movement();
        Phase();
    }
}
