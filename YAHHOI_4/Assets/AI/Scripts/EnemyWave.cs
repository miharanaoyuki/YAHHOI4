using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    Rigidbody2D rb;     //���W�b�h�{�f�B2D
    public int HP;      //�̗�
    public float Xmove = 0.0f;  //X���̑��x
    public float Ymove = 0.0f;  //Y���̑��x
    float x, y = 0.0f;  //�c��
    public int ReverseTime = 0;//�㉺���]����Ԋu
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

        //���ɂ͕��̒l��
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

        //�ǂ���ʊO�ɏo�����������

    }
}
