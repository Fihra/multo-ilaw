using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToTitle : MonoBehaviour
{
    AK.Wwise.Event musicEvent;
    List<AK.Wwise.State> musicStates;

    private void Start()
    {
        musicEvent = GameObject.Find("MusicManager").GetComponent<MusicManager>().musicEvent;
        musicStates = GameObject.Find("MusicManager").GetComponent<MusicManager>().musicStates;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            MusicManager.finishedGame = true;
            StartCoroutine(ToCoda());
        }
    }

    IEnumerator ToCoda()
    {
        yield return new WaitForSeconds(3.5f);
        Destroy(GameObject.Find("MusicManager"));
        SceneManager.LoadScene(0);
    }
}
