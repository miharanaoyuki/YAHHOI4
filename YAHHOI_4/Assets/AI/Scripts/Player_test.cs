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

    // Start is called before the first frame update
    void Start()
    {
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
        if (Input.GetKey(KeyCode.RightArrow))
        {
            px += speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            px += -speed;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            py += speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
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