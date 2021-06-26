using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseCooldown : MonoBehaviour
{
    private uint cooldownSoundID;
    private Slider phaseSlider;
    private float phaseSliderValue;

    void Start()
    {
        phaseSlider = gameObject.GetComponent<Slider>();
        phaseSliderValue = phaseSlider.value;
    }

    void Update()
    {
        phaseSliderValue = phaseSlider.value;

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
