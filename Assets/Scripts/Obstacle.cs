using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public float speed;
    public GameObject effect;
    BoxCollider2D playerCollider;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < -10)
        {        
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            playerCollider = collision.GetComponent<BoxCollider2D>();

            if(playerCollider.isTrigger)
            {
                Instantiate(effect, transform.position, Quaternion.identity);
                collision.GetComponent<Player>().health -= damage;
                Destroy(gameObject);
            }

        }
    }
}
