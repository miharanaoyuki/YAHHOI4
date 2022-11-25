using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawn_Nomal : MonoBehaviour
{
    public Transform target;        //Player�̍��W�擾�p
    public GameObject[] enemyList;  //�G�I�u�W�F�N�g�w��p�F�z��Ȃ̂ŕ����w���
    Vector2 pos;                    //�o��������I�u�W�F�N�g�̍��W�p
    public int Time = 0;            //���Ԋu�̎w������邽�߂̂��
    public float settingX = 0.0f;    //�G�̏o�����W�̎w��(Player���獶-:�E+�ɂǂꂾ������Ă��邩)
    private int reset = 0;          //�J�E���g

    bool SpawnFlag = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!SpawnFlag)
        {
            reset++;
            //reset��time�𒴂�����
            if (Time < reset)
            {
                //�����_����ނƈʒu�����߂�
                int index = Random.Range(0, enemyList.Length);
                int PosY = Random.Range(-10, 10);
                pos = enemyList[index].transform.position;
                pos.x += target.position.x + settingX;//������Player��荶�E�ɍ��W�𑫂�
                Instantiate(enemyList[index], new Vector2(pos.x,PosY), Quaternion.identity);
                reset = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Player�����ɓ�������
        if (collision.gameObject.CompareTag("Player"))
        {
            SpawnFlag = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Player���O�ɏo����
        if (collision.gameObject.CompareTag("Player"))
        {
            SpawnFlag = true;
            reset = 0;
        }
    }
}
