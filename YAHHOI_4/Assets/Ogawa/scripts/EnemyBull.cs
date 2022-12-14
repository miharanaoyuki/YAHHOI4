using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBull : MonoBehaviour
{
    public float b_x = 0.0f;//弾の速度
    public float Limit = 0;   //表示時間
    public GameObject original;//攻撃時の弾指定用:選択可
    private GameObject bullet;//攻撃時の弾:選択不可
    private Rigidbody2D rb;//Rigidbody2D
    private Vector2 newPos;//位置情報取得用

    public float move;
    public float time;
    private int counter;

    void Start()
    {
        move = move / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (time == counter)
        {
            newPos = this.transform.position;//ここでプレイヤーの座標を取得
            newPos.x += -1;
            newPos.y += 0;

            //生成、右に飛ばす
            bullet = Instantiate(original) as GameObject;
            bullet.transform.position = newPos;
            Destroy(bullet, Limit);
            rb = bullet.GetComponent<Rigidbody2D>();

            rb.velocity = new Vector2(b_x, 0);

            counter = 0;
        }
        counter++;
    }

    private void OnCollisionTrigger2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
