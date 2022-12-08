using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    Rigidbody2D rb;     //���W�b�h�{�f�B2D
    public int HP;      //�̗�
    private Vector2 vec;
    public float Xmove = 0.0f;  //X���̑��x
    public float Ymove = 0.0f;  //Y���̑��x
    public int ReverseTime = 0;//�㉺���]����Ԋu
    private int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += 1;

        vec.x += -Xmove;
        vec.y += Ymove;

        if (ReverseTime <= time)
        {
            Ymove = -Ymove;
            time = 0;
        }

        //���ɂ͕��̒l��
        rb.velocity = new Vector2(Xmove, Ymove);
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
        //�ǂ���ʊO�ɏo�����������
    }
}
