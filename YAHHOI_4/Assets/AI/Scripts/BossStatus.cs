using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossStatus : MonoBehaviour
{
    [SerializeField] private GameObject effect;
    [SerializeField] private GameObject enemy;
    public Slider slider;
    private Rigidbody2D rb;//boss_rigidbody
    private Vector2 vec;

    private float Xspeed = 0.0f, Yspeed = 0.0f;
    private int time = 0, reverse = 0;
    public int limit = 0;
    private int turn = 0;
    bool atkFlag = false;
    //[SerializeField] private AudioClip hitClip;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        slider.value = 30;
        Xspeed = 4.0f;
        Yspeed = 4.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 scale = transform.localScale;
        scale.x = 2;
        time++;//Y”½“]
        reverse++;//X”½“]

        vec.y += Yspeed;
        vec.x += Xspeed;

        if (time % 60 == 0)
        {
            Instantiate(enemy, this.gameObject.transform.localPosition, Quaternion.identity);
        }


        if (time > 300)
        {
            Yspeed = -Yspeed;
            time = 0;
            turn += 1;
        }
        if (reverse > 360)
        {
            Xspeed = -Xspeed;
            reverse = 0;
            turn += 1;
        }

        if (turn % 2 == 0) { scale.x = 2; }
        else { scale.x = -2; }

        if (slider.value == 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Clear");
        }
        rb.velocity = new Vector2(Xspeed, Yspeed);
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Vector3 hitPos = collision.ClosestPoint(this.transform.position);
            slider.value--;

            Instantiate(effect, hitPos, Quaternion.identity);
        }
    }
}
