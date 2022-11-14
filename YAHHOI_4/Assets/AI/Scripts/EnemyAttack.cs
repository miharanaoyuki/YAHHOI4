using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject enemy;
    private GameObject enemyBullet;

    private Rigidbody2D rb;
    private Vector2 pos;

    public float speed = 0.0f;  //’e‘¬
    private int Limit = 0;      //”­ŽËŠÔŠu

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Limit += 1;

        if (Limit % 60 == 0)
        {
            pos = this.transform.position;
            pos.x += -1;
            pos.y += 0;

            enemyBullet = Instantiate(enemy);
            enemyBullet.transform.position = pos;

            Destroy(enemyBullet, 3.0f);
            rb = enemyBullet.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(-speed, 0);
        }
    }
}