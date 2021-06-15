using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMusic : MonoBehaviour
{
    public AK.Wwise.Event bgmEvent;

    // Start is called before the first frame update
    void Start()
    {
        bgmEvent.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
