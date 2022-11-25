using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float b_x = 0.0f;//弾の速度
    public float Limit = 0;   //表示時間
    public GameObject original;//攻撃時の弾指定用:選択可
    private GameObject bullet;//攻撃時の弾:選択不可
    private Rigidbody2D rb;//Rigidbody2D
    private Vector2 newPos;//位置情報取得用
    private float offset = 0;

    bool pushFlag = true;//押したかどうか
    bool returnFlag = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            offset = -1;
            returnFlag = false;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            offset = 1;
            returnFlag = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pushFlag)
            {
                pushFlag = false;
                newPos = this.transform.position;//ここでプレイヤーの座標を取得
                newPos.x += offset;
                newPos.y += 0;

                //生成、右に飛ばす
                bullet = Instantiate(original) as GameObject;
                bullet.transform.position = newPos;
                Destroy(bullet, Limit);
                rb = bullet.GetComponent<Rigidbody2D>();
                if (!returnFlag)
                {
                    rb.velocity = new Vector2(-b_x, 0);
                }
                else
                {
                    rb.velocity = new Vector2(b_x, 0);
                }
            }
        }
        else
        {
            pushFlag = true;
        }
    }
}
