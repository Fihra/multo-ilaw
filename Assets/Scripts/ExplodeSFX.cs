using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeSFX : MonoBehaviour
{
    public AK.Wwise.Event explodeSFXEffect;
    BoxCollider2D playerCollider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerCollider = collision.GetComponent<BoxCollider2D>();
            if(playerCollider.isTrigger)
            {
                explodeSFXEffect.Post(gameObject);
            }
            
        }
    }
}
