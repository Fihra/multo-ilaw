using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    Scene currentScene;

    public AK.Wwise.Event musicEvent;
    public List<AK.Wwise.State> musicStates = new List<AK.Wwise.State>();

    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        musicStates[0].SetValue();
        musicEvent.Post(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "GameScene")
        {
            musicStates[1].SetValue();

        }
        //Debug.Log(currentScene.name);
    }
}
