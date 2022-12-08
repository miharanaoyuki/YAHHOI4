using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //�ړ����x
    public float speed;

    //�̗̓o�[�̐ݒ�
    public Slider slider;

    //�V�[���̔�Ԑ�̕ϐ�
    public string scene;

    //�_���[�W�t���O
    private bool on_damage = false;
    private SpriteRenderer renderer;

    void Start()
    {
        slider.value = 5;
        speed = speed / 100;
        //�_�ŏ����p�ɌĂяo��
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 Position = transform.position;

        //�_���[�W�t���O��true�ł���Γ_��
        if(on_damage)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 10));
            renderer.color = new Color(1f, 1f, 1f, level);
        }

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

        Debug.Log(speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�G�Ƃ̏���
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
        //�񕜏���
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
