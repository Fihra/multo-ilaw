using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionToEnd : MonoBehaviour
{
    public Animator transitionAnim;
    public GameObject scoreObject;
    ScoreManager scoreManager;
    int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = scoreObject.GetComponent<ScoreManager>();
        currentScore = scoreManager.score;
    }

    // Update is called once per frame
    void Update()
    {
        currentScore = scoreManager.score;
        if(currentScore >= 50)
        {
            StartCoroutine(FadeScene());
        }
    }

    IEnumerator FadeScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
