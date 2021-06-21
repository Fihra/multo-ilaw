using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseCooldown : MonoBehaviour
{
    //public AK.Wwise.Event cooldownEvent;

    private uint cooldownSoundID;

    private Slider phaseSlider;
    private float phaseSliderValue;

    // Start is called before the first frame update
    void Start()
    {
        
        phaseSlider = gameObject.GetComponent<Slider>();
        phaseSliderValue = phaseSlider.value;
    }

    // Update is called once per frame
    void Update()
    {

        phaseSliderValue = phaseSlider.value;
        //Debug.Log(phaseSliderValue);

        if(phaseSliderValue == 1f)
        {
            AkSoundEngine.SetRTPCValue("Cooldown", 0f);
        }
        
        if (phaseSliderValue == 0f)
        {
            cooldownSoundID = AkSoundEngine.PostEvent("Cooldown", gameObject);
            AkSoundEngine.SetRTPCValue("Cooldown", 100.0f);
           
        }
    }
}
