using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawn_Nomal : MonoBehaviour
{
    public Transform target;        //Playerの座標取得用
    public GameObject[] enemyList;  //敵オブジェクト指定用：配列なので複数指定可
    Vector2 pos;                    //出現させるオブジェクトの座標用
    public int Time = 0;            //一定間隔の指定をするためのやつ
    public float settingX = 0.0f;    //敵の出現座標の指定(Playerから左-:右+にどれだけ離れているか)
    private int reset = 0;          //カウント

    bool SpawnFlag = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!SpawnFlag)
        {
            reset++;
            //resetがtimeを超えた時
            if (Time < reset)
            {
                //ランダム種類と位置を決める
                int index = Random.Range(0, enemyList.Length);
                int PosY = Random.Range(-10, 10);
                pos = enemyList[index].transform.position;
                pos.x += target.position.x + settingX;//ここでPlayerより左右に座標を足す
                Instantiate(enemyList[index], new Vector2(pos.x,PosY), Quaternion.identity);
                reset = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Playerが中に入ったら
        if (collision.gameObject.CompareTag("Player"))
        {
            SpawnFlag = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Playerが外に出たら
        if (collision.gameObject.CompareTag("Player"))
        {
            SpawnFlag = true;
            reset = 0;
        }
    }
}
