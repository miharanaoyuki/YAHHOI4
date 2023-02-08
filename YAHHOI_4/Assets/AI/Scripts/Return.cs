using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : MonoBehaviour
{
    public int HP;      //�̗�
    public GameObject effect;
    public AudioClip clip;
    public AudioClip hit;
    public float Xmove = 0.0f, Ymove = 0.0f;  //X���̑��x/Y���̑��x
    private int turn = 0;

    [Tooltip("�㉺���]����Ԋu")]
    public int ReverseTime = 0;//�㉺���]����Ԋu

    [Tooltip("���E���]����Ԋu")]
    public int MOVE_Rerutrn = 0;

    private Vector2 vec;
    Rigidbody2D rb;     //���W�b�h�{�f�B2D
    private int time,r_time = 0;

    bool OnFlag = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        clip = gameObject.GetComponent<AudioSource>().clip;
        hit = gameObject.GetComponent<AudioSource>().clip;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 scale = transform.localScale;

        time += 1;
        r_time += 1;
        if (ReverseTime <= time)
        {
            Ymove = -Ymove;
            time = 0;
        }

        //���E���]�p
        if (MOVE_Rerutrn <= r_time)
        {
            Xmove = -Xmove;
            r_time = 0;
            turn += 1;
            if (turn % 2 == 0){ scale.x = 1; }
            else { scale.x = -1; }
        }

        vec.x += -Xmove;
        vec.y += Ymove;

        transform.localScale = scale;
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
            AudioSource.PlayClipAtPoint(hit, transform.position);
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
