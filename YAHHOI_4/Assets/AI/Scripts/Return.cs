using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : MonoBehaviour
{
    public int HP;      //体力
    public GameObject effect;
    public AudioClip clip;
    public AudioClip hit;
    public float Xmove = 0.0f, Ymove = 0.0f;  //X軸の速度/Y軸の速度

    [Tooltip("上下反転する間隔")]
    public int ReverseTime = 0;//上下反転する間隔

    [Tooltip("左右反転する間隔")]
    public int MOVE_Rerutrn = 0;

    private Vector2 vec;
    Rigidbody2D rb;     //リジッドボディ2D
    private int time,r_time = 0;

    bool OnFlag = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        clip = gameObject.GetComponent<AudioSource>().clip;
        hit = gameObject.GetComponent<AudioSource>().clip;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += 1;
        r_time += 1;
        if (ReverseTime <= time)
        {
            Ymove = -Ymove;
            time = 0;
        }

        //左右反転用
        if (MOVE_Rerutrn <= r_time)
        {

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
            AudioSource.PlayClipAtPoint(hit, transform.position);
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
