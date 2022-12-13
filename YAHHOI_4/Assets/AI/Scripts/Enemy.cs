using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject effect;
    //private GameObject myObject;
    public AudioClip clip;
    Rigidbody2D rb;     //���W�b�h�{�f�B2D
    public int HP;      //�̗�
    public float Xmove = 0.0f;  //X���̑��x
    public float Ymove = 0.0f;
    private Vector2 vec;

    // Start is called before the first frame update
    void Start()
    {
        //myObject = GetComponent<GameObject>();
        rb = GetComponent<Rigidbody2D>();
        clip = gameObject.GetComponent<AudioSource>().clip;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vec.x += Xmove;
        vec.y += Ymove;

        if (HP == 0)
        {
            //effect.transform.localScale = this.gameObject.transform.localScale;
            //GetComponent<AudioSource>().PlayOneShot(clip);
            Instantiate(effect.transform, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }

        //���ɂ͕��̒l��
        rb.velocity = new Vector2(Xmove,Ymove);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //HitFlag = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HP--;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
