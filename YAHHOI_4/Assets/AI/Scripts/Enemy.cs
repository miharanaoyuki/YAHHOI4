using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;     //リジッドボディ2D
    public int HP;      //体力
    GameObject enemy;   //オブジェクト
    float move = 0.0f;  //速度
    float x, y = 0.0f;  //縦横

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        //左には負の値を
        x += -move;
        Instantiate(enemy);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HP--;
        }
        if (HP < 0)
        {
            Destroy(enemy.gameObject);
        }
    }
}
