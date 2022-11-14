using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    Rigidbody2D rb;     //リジッドボディ2D
    public int HP;      //体力
    public float Xmove = 0.0f;  //X軸の速度
    public float Ymove = 0.0f;  //Y軸の速度
    float x, y = 0.0f;  //縦横
    public int ReverseTime = 0;//上下反転する間隔
    private int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += 1;
        x -= Xmove;
        y -= Ymove;
        if (ReverseTime <= time)
        {
            y = -y;
            time = 0;
        }

        //左には負の値を
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

        //壁か画面外に出たら消したい

    }
}
