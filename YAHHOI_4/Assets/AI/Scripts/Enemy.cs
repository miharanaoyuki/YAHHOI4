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
    float x, y = 0.0f;  //縦横

    // Start is called before the first frame update
    void Start()
    {
        clip = gameObject.GetComponent<AudioSource>().clip;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        x -= Xmove;
        y += Ymove;
        //左には負の値を
        rb.velocity = new Vector2(x / 1000, y / 1000);
        Debug.Log("残り：" + HP);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //HitFlag = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HP--;
            if (HP == 0)
            {
                GetComponent<AudioSource>().PlayOneShot(clip);
                Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
