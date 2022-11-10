using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_copy : MonoBehaviour
{
    public float speed;
    public GameObject bullet;//攻撃時の弾:選択可
    private Vector3 pos;//位置情報取得用
    private float b_x, b_y = 0.0f;//弾の座標
    bool pushFlag = true;//押したかどうか

    void Start()
    {
        speed = speed / 400;
    }

    void Update()
    {
        Vector2 Position = transform.position;

        //右に移動
        if (Input.GetKey(KeyCode.D)||(Input.GetKey(KeyCode.RightArrow)))
        {
            Position.x += speed;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        //左に移動
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            Position.x -= speed;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow)))
        {
            Position.y += speed;
        }
        if (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow)))
        {
            Position.y -= speed;
        }

        transform.position = Position;

        if (Input.GetKey(KeyCode.Space))
        {
            if (pushFlag)
            {
                pushFlag = false;
                pos=this.transform.position;//ここでプレイヤーの座標を取得
                //生成、右に飛ばす
                Instantiate(bullet);
            }
        }
    }
}
