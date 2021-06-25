using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToTitle : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Return))
        {
            MusicManager.finishedGame = true;
            Destroy(GameObject.Find("MusicManager"));
            SceneManager.LoadScene(0);

        }
    }
}
