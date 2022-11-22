using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawn_Nomal : MonoBehaviour
{
    [SerializeField]List<GameObject> enemyList;//�����I�u�W�F�N�g
    [SerializeField] Transform pos;//�����ʒu
    [SerializeField] Transform pos2;
    private float minX, minY, maxX, maxY;//�����͈�

    public int Time = 0;
    private int reset = 0;
    bool SpawnFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        minX = Mathf.Min(pos.position.x, pos2.position.x);
        maxX = Mathf.Max(pos.position.x, pos2.position.x);
        minY = Mathf.Min(pos.position.y, pos2.position.y);
        maxY = Mathf.Max(pos.position.y, pos2.position.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!SpawnFlag)
        {
            reset++;
            //time��reset�𒴂�����
            if (Time > reset)
            {
                reset = 0;
                //�����_����ނƈʒu�����߂�
                int index = Random.Range(0, enemyList.Count);
                float posX = Random.Range(minX, maxX);
                float posY = Random.Range(minY, maxY);

                Instantiate(enemyList[index], new Vector3(posX, posY, 0), Quaternion.identity);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpawnFlag = false;
        }
    }
}
