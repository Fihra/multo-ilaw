using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseSFX : MonoBehaviour
{
    BoxCollider2D playerTrigger;

    private uint phaseID;

    // Start is called before the first frame update
    void Start()
    {
        playerTrigger = gameObject.GetComponent<BoxCollider2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTrigger.isTrigger)
        {
            AkSoundEngine.SetRTPCValue("Volume", 0f, gameObject);
        }

        if(!playerTrigger.isTrigger)
        {
            phaseID = AkSoundEngine.PostEvent("Phase", gameObject);
            AkSoundEngine.SetRTPCValue("Volume", 50.0f, gameObject);
        }

    }
}
