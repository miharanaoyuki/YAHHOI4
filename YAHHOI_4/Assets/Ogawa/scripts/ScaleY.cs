using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleY : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            transform.localScale -= new Vector3(0, 0.25f, 0);
        }
        if (transform.localScale.y == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
