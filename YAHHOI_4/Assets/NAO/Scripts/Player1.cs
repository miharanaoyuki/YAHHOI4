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

    //�_���[�W�t���O
    private bool on_damage = false;
    private SpriteRenderer renderer;

    //�̗͒l�̐��l���Ɖ���
    Text HPtext;
    private string HPstring;
    private int nowHP;//���̎��̗̑�
    void Start()
    {
        slider.value = 5;
        speed = speed / 100;
    }

    void Update()
    {
        Vector2 Position = transform.position;

        //�E�Ɉړ�
        if (Input.GetKey(KeyCode.D)||(Input.GetKey(KeyCode.RightArrow)))
        {
            Position.x += speed;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        //���Ɉړ�
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
        //�G�Ƃ̏���
        if (collision.gameObject.CompareTag("Enemy"))
        {
            slider.value--;
        }
        if (slider.value == 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(scene);
        }


        //�񕜏���
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
        // �_���[�W�t���OON
        on_damage = true;

        // �R���[�`���J�n
        StartCoroutine("WaitForIt");
    }

    IEnumerator WaitForIt()
    {
        // 1�b�ԏ������~�߂�
        yield return new WaitForSeconds(1.5f);

        // �P�b��_���[�W�t���O��false�ɂ��ē_�ł�߂�
        on_damage = false;
        renderer.color = new Color(1f, 1f, 1f, 1f);
    }
}
