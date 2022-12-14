using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject effect;
    public AudioClip clip;
    Rigidbody2D rb;     //リジッドボディ2D
    public int HP;      //体力
    public float Xmove = 0.0f;  //X軸の速度
    public float Ymove = 0.0f;
    private Vector2 vec;
    bool OnFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        clip = gameObject.GetComponent<AudioSource>().clip;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vec.x += Xmove;
        vec.y += Ymove;

        if (HP == 0)
        {
            Instantiate(effect.transform, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }

        //左には負の値を
        rb.velocity = new Vector2(Xmove,Ymove);

        if (!OnFlag)
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
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Field"))
        {
            OnFlag = false;
        }
    }
}
