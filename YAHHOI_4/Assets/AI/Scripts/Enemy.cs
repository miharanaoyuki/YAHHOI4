using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject effect;
    [SerializeField] private AudioSource[] audioBox;//0=HIT,1=DEATH

    private AudioSource HitClip;   //0
    private AudioSource DeathClip; //1

    Rigidbody2D rb;//リジッドボディ2D
    public int HP = 0;//体力
    public float Xmove = 0.0f;  //X軸の速度
    public float Ymove = 0.0f;
    private Vector2 vec;
    bool OnFlag = true;//範囲内かどうか

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioBox = GetComponents<AudioSource>();
        HitClip = audioBox[0];
        DeathClip = audioBox[1];
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
            DeathClip.PlayOneShot(DeathClip.clip);
            //DeathClip.PlayOneShot(audioBox[1].clip);
        }

        //範囲外に出たら
        if (!OnFlag)
        {
            Destroy(this.gameObject);
        }

        //移動情報の更新
        rb.velocity = new Vector2(Xmove, Ymove);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HP--;
            HitClip.PlayOneShot(HitClip.clip);
            //HitClip.PlayOneShot(audioBox[0].clip);
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