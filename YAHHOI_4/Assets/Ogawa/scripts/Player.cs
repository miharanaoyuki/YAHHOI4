using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //移動速度
    public float speed;

    //体力バーの設定
    public Slider slider;

    //シーンの飛ぶ先の変数
    public string scene;

    //ダメージフラグ
    private bool on_damage = false;
    private SpriteRenderer renderer;

    void Start()
    {
        slider.value = 5;
        speed = speed / 100;
        //点滅処理用に呼び出す
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 Position = transform.position;

        //ダメージフラグがtrueであれば点滅
        if(on_damage)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            renderer.color = new Color(1f, 1f, 1f, level);
        }

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

        Debug.Log(speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //敵との処理
        if (!on_damage && collision.gameObject.CompareTag("Enemy"))
        {
            slider.value--;
            OnDamageEffect();
        }
        if (slider.value == 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(scene);
        }
        //回復処理
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("numa"))
        {
            speed = 0.05f;
        }

        if (!on_damage && collision.gameObject.CompareTag("EBull"))
        {
            slider.value--;
            OnDamageEffect();
        }
        if (slider.value == 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(scene);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        speed = 0.1f;
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
