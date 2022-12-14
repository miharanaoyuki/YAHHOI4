using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public int HP;      //体力
    public GameObject effect;
    public AudioClip clip;
    public float Xmove = 0.0f, Ymove = 0.0f;  //X軸の速度/Y軸の速度

    public int ReverseTime = 0;//上下反転する間隔

    private Vector2 vec;
    Rigidbody2D rb;     //リジッドボディ2D
    private int time = 0;

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
        time += 1;

        if (ReverseTime <= time)
        {
            Ymove = -Ymove;
            time = 0;
        }

        vec.x += -Xmove;
        vec.y += Ymove;

        //左には負の値を
        rb.velocity = new Vector2(Xmove, Ymove);
        if (!OnFlag)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HP--;
        }
        if (HP == 0)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(clip, transform.position);
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
