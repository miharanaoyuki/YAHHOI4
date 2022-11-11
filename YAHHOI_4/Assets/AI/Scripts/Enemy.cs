using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;     //���W�b�h�{�f�B2D
    public int HP;      //�̗�
    GameObject enemy;   //�I�u�W�F�N�g
    public float move = 0.0f;  //���x
    float x, y = 0.0f;  //�c��

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        x -= move;

        //���ɂ͕��̒l��
        rb.velocity = new Vector2(x, y);
        //Instantiate(enemy);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HP--;
        }
        if (HP < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
