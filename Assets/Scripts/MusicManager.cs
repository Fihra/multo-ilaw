using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    Scene currentScene;

    public static bool finishedGame = false;
    public AK.Wwise.Event musicEvent;
    public List<AK.Wwise.State> musicStates = new List<AK.Wwise.State>();

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        
        if(!finishedGame)
        {
            musicStates[0].SetValue();
            musicEvent.Post(gameObject);
        }
        finishedGame = false;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene();

        switch (currentScene.name)
        {
            case "GameScene":
                musicStates[1].SetValue();
                break;
            case "EndScene":
                musicStates[2].SetValue();
                if (finishedGame)
                {
                    StartCoroutine(ToCoda());
                }
                break;
            default:
                return;
        }
    }

    IEnumerator ToCoda()
    {
        musicStates[0].SetValue();
        yield return new WaitForSeconds(3.5f);
    }
}
