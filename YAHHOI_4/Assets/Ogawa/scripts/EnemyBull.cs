using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBull : MonoBehaviour
{
    public float b_x = 0.0f;//�e�̑��x
    public float Limit = 0;   //�\������
    public GameObject original;//�U�����̒e�w��p:�I����
    private GameObject bullet;//�U�����̒e:�I��s��
    private Rigidbody2D rb;//Rigidbody2D
    private Vector2 newPos;//�ʒu���擾�p

    // Update is called once per frame
    void Update()
    {
        newPos = this.transform.position;//�����Ńv���C���[�̍��W���擾
        newPos.x += -1;
        newPos.y += 0;

        //�����A�E�ɔ�΂�
        bullet = Instantiate(original) as GameObject;
        bullet.transform.position = newPos;
        Destroy(bullet, Limit);
        rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(b_x, 0);

    }

    private void OnCollisionTrigger2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
