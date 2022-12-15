using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatus : MonoBehaviour
{
    private int HP = 0, time = 0, limit = 0, reverse = 0;
    private Vector2 vec;
    private Rigidbody2D rb;
    bool AttackFlag = true;
    private float Xspeed = 0, Yspeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        HP = 50;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        reverse++;
        time++;
        //10•b–ˆ‚É“ËiUŒ‚‚³‚¹‚½‚¢
        if (time > 600)
        {
            AttackFlag = false;
            time = 0;
        }

        //true
        if (AttackFlag)
        {
            if (reverse > 180)
            {
                Yspeed = -Yspeed;
                reverse = 0;
            }
            vec.y = Yspeed;
            Yspeed = 2.0f;
        }

        //false
        if (!AttackFlag)
        {
            limit++;
            vec.x = Xspeed;
            Xspeed -= 0.01f;
            if (limit > 60)
            {
                Xspeed = -Xspeed;
                limit = 0;
            }
        }
        Xspeed = 4.0f;

        AttackFlag = true;

        rb.velocity = new Vector2(vec.x, vec.y);

        if (HP == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HP--;
        }
    }
}
