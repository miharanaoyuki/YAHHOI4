using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;     //���W�b�h�{�f�B2D
    public int HP;      //�̗�
    public float Xmove = 0.0f;  //X���̑��x
    float x, y = 0.0f;  //�c��

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        x -= Xmove;
        y += 0;
        //���ɂ͕��̒l��
        rb.velocity = new Vector2(x / 1000, y / 1000);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HP--;
        }
        if (HP == 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
