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
        AkSoundEngine.SetRTPCValue("Volume", 0f, gameObject);
        phaseID = AkSoundEngine.PostEvent("Phase", gameObject);
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
            
            AkSoundEngine.SetRTPCValue("Volume", 50.0f, gameObject);
        }

    }
}
