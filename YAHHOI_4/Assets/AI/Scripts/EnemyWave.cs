using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public int HP;      //�̗�
    public GameObject effect;
    public AudioClip clip;
    public float Xmove = 0.0f, Ymove = 0.0f;  //X���̑��x/Y���̑��x

    public int ReverseTime = 0;//�㉺���]����Ԋu

    private Vector2 vec;
    Rigidbody2D rb;     //���W�b�h�{�f�B2D
    private int time = 0;

    bool OnFlag = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        clip = gameObject.GetComponent<AudioSource>().clip;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += 1;

        if (ReverseTime <= time)
        {
            Ymove = -Ymove;
            time = 0;
        }

        vec.x += -Xmove;
        vec.y += Ymove;

        //���ɂ͕��̒l��
        rb.velocity = new Vector2(Xmove, Ymove);
        if (!OnFlag)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HP--;
        }
        if (HP == 0)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Field"))
        {
            OnFlag = false;
        }
    }
}
