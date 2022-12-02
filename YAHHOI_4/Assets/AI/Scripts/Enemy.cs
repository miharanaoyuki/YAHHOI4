using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject effect;
    public AudioClip clip;
    Rigidbody2D rb;     //���W�b�h�{�f�B2D
    public int HP;      //�̗�
    public float Xmove = 0.0f;  //X���̑��x
    public float Ymove = 0.0f;
    float x, y = 0.0f;  //�c��

    // Start is called before the first frame update
    void Start()
    {
        clip = gameObject.GetComponent<AudioSource>().clip;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        x -= Xmove;
        y += Ymove;
        //���ɂ͕��̒l��
        rb.velocity = new Vector2(x / 1000, y / 1000);
        Debug.Log("�c��F" + HP);
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
            if (HP == 0)
            {
                GetComponent<AudioSource>().PlayOneShot(clip);
                Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
