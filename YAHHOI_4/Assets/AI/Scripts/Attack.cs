using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float b_x = 0.0f;//�e�̑��x
    public float Limit = 0;   //�\������
    public GameObject original;//�U�����̒e�w��p:�I����
    private GameObject bullet;//�U�����̒e:�I��s��
    private Rigidbody2D rb;//Rigidbody2D
    private Vector2 newPos;//�ʒu���擾�p
    private float offset = 0;//�ʒu�𒆐S���炸�炷�p
    public AudioClip clip;//�U������SE
    bool pushFlag = true;//���������ǂ���
    bool returnFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        offset = 1.25f;
        clip = gameObject.GetComponent<AudioSource>().clip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            offset = -1.25f;
            returnFlag = false;
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                offset = 1.25f;
                returnFlag = true;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            offset = 1.25f;
            returnFlag = true;
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                offset = -1.25f;
                returnFlag = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pushFlag)
            {
                pushFlag = false;
                newPos = this.transform.position;//�����Ńv���C���[�̍��W���擾
                newPos.x += offset;
                newPos.y += 0;

                //�����A�E�ɔ�΂�
                bullet = Instantiate(original) as GameObject;
                bullet.transform.position = newPos;
                Destroy(bullet, Limit);
                rb = bullet.GetComponent<Rigidbody2D>();
                if (!returnFlag)
                {
                    rb.velocity = new Vector2(-b_x, 0);
                }
                else
                {
                    rb.velocity = new Vector2(b_x, 0);
                }
                GetComponent<AudioSource>().PlayOneShot(clip);
            }
        }
        else
        {
            pushFlag = true;
        }
    }
}
