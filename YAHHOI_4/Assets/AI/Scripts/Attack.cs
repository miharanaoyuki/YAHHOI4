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

    bool pushFlag = true;//���������ǂ���

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (pushFlag)
            {
                pushFlag = false;
                newPos = this.transform.position;//�����Ńv���C���[�̍��W���擾
                newPos.x += 1;
                newPos.y += 0;

                //�����A�E�ɔ�΂�
                bullet = Instantiate(original) as GameObject;
                bullet.transform.position = newPos;
                Destroy(bullet, Limit);
                rb = bullet.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(b_x, 0);
            }
        }
        else
        {
            pushFlag = true;
        }
    }
}
