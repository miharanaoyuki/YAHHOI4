using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossStatus : MonoBehaviour
{
    public Slider slider;
    private Rigidbody2D rb;//boss_rigidbody
    private Vector2 vec;

    private float Xspeed = 0.0f, Yspeed = 0.0f;
    private int HP = 0, time = 0, reverse = 0;
    public int limit = 0;

    bool atkFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        slider.value = 30;
        HP = 30;
        Xspeed = 4.0f;
        Yspeed = 4.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time++;//Y???]
        reverse++;//X???]

        vec.y += Yspeed;
        vec.x += Xspeed;

        if (time > 300)
        {
            Yspeed = -Yspeed;
            time = 0;
        }
        if (reverse > 360)
        {
            Xspeed = -Xspeed;
            reverse = 0;
        }

        if (HP == 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameClear");
        }
        rb.velocity = new Vector2(Xspeed, Yspeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            slider.value--;
            HP--;
        }
    }
}
