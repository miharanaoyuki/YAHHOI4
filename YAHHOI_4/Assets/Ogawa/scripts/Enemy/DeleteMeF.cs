using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMeF : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") ||
            collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")||
            collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
