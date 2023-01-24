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

    //ダメージフラグ
    private bool on_damage = false;
    private SpriteRenderer renderer;

    //体力値の数値化と可視化
    Text HPtext;
    private string HPstring;
    private int nowHP;//その時の体力
    void Start()
    {
        slider.value = 5;
        speed = speed / 100;
    }

    void Update()
    {
        Vector2 Position = transform.position;

        //右に移動
        if (Input.GetKey(KeyCode.D)||(Input.GetKey(KeyCode.RightArrow)))
        {
            Position.x += speed;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        //左に移動
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
        //敵との処理
        if (collision.gameObject.CompareTag("Enemy"))
        {
            slider.value--;
        }
        if (slider.value == 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(scene);
        }


        //回復処理
        if (collision.gameObject.CompareTag("potion1"))
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

    void OnDamageEffect()
    {
        // ダメージフラグON
        on_damage = true;

        // コルーチン開始
        StartCoroutine("WaitForIt");
    }

    IEnumerator WaitForIt()
    {
        // 1秒間処理を止める
        yield return new WaitForSeconds(1.5f);

        // １秒後ダメージフラグをfalseにして点滅を戻す
        on_damage = false;
        renderer.color = new Color(1f, 1f, 1f, 1f);
    }
}
