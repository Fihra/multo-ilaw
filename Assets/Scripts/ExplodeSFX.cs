using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeSFX : MonoBehaviour
{
    public float frequency = 440.0f;
    public float increment;
    public float phase;
    public float sampling_frequency = 48000.0f;

    public float gain;
    public float volume = 0.1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            gain = volume;
            gain = 0.0f;
        }
    }

    private void OnAudioFilterRead(float[] data, int channels)
    {
        increment = (float)(frequency * 2.0 * Mathf.PI / sampling_frequency);

        for(int i = 0; i < data.Length; i += channels)
        {
            phase += increment;
            data[i] = (gain * Mathf.Sin(phase));
            if(channels == 2)
            {
                data[i + 1] = data[i];
            }

            if(phase > (Mathf.PI * 2))
            {
                phase = 0.0f;
            }
        }
    }
}
