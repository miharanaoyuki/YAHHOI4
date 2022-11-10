using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_copy : MonoBehaviour
{
    public float speed;
    public GameObject bullet;//�U�����̒e:�I����
    private Vector3 pos;//�ʒu���擾�p
    private float b_x, b_y = 0.0f;//�e�̍��W
    bool pushFlag = true;//���������ǂ���

    void Start()
    {
        speed = speed / 400;
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

        if (Input.GetKey(KeyCode.Space))
        {
            if (pushFlag)
            {
                pushFlag = false;
                pos=this.transform.position;//�����Ńv���C���[�̍��W���擾
                //�����A�E�ɔ�΂�
                Instantiate(bullet);
            }
        }
    }
}
