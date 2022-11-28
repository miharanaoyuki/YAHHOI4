using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    public float speed;

    public Slider slider;

    public string scene;

    void Start()
    {
        slider.value = 5;
        speed = speed / 100;
    }

    void Update()
    {
        Vector2 Position = transform.position;

        //âEÇ…à⁄ìÆ
        if (Input.GetKey(KeyCode.D)||(Input.GetKey(KeyCode.RightArrow)))
        {
            Position.x += speed;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        //ç∂Ç…à⁄ìÆ
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            Position.x -= speed;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow)))
        {
            Position.y += speed;
        }
        if (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow)))
        {
            Position.y -= speed;
        }

        transform.position = Position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ìGÇ∆ÇÃèàóù
        if (collision.gameObject.CompareTag("Enemy"))
        {
            slider.value--;
        }
        if (slider.value == 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(scene);
        }
        //âÒïúèàóù
        if(collision.gameObject.CompareTag("potion1"))
        {
            slider.value += 1;
        }
        if (collision.gameObject.CompareTag("potion2"))
        {
            slider.value += 2;
        }
        if (collision.gameObject.CompareTag("potion3"))
        {
            slider.value += 4;
        }
    }
}
