using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_test : MonoBehaviour
{
    public Slider slider;//�X���C�_�[
    Rigidbody2D pr;//�ړ�
    float px, py;//�ړ��X�V�p

    public string SceneName;//�Q�[���I�[�o�[�ɂȂ������p
    public float speed;//�v���C���[�̈ړ����x
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        this.sr = GetComponent<SpriteRenderer>();
        slider.value = 5;//�̗͍ő�l�w��(������)
        //�������擾
        pr = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        px = 0.0f;
        py = 0.0f;
        //�ړ�
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            px += speed;
            sr.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            px += -speed;
            sr.flipX = true;
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            py += speed;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            py += -speed;
        }
        pr.velocity = new Vector2(px, py);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //�G�ɓ����������̏���
        if (collision.gameObject.CompareTag("Enemy"))
        {
            slider.value--;
            //0�ȉ��F���@�V�[���`�F���W
            if (slider.value == 0)
            {
                SceneManager.LoadScene(SceneName);
            }
        }
        if (collision.gameObject.CompareTag("potion1"))
        {
            slider.value += 1;
            if (slider.value <= 6)
            {
                slider.value = 5;
            }
        }
        if (collision.gameObject.CompareTag("potion2"))
        {
            slider.value += 2;
            if (slider.value <= 6)
            {
                slider.value = 5;
            }
        }
        if (collision.gameObject.CompareTag("potion3"))
        {
            slider.value += 4;
            if (slider.value <= 6)
            {
                slider.value = 5;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Item"))
        //{
        //    slider.value += 1;
        //    Debug.Log(slider.value);
        //}
    }
}