using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawn_Nomal : MonoBehaviour
{
    [SerializeField]List<GameObject> enemyList;//生成オブジェクト
    [SerializeField] Transform pos;//生成位置
    [SerializeField] Transform pos2;
    private float minX, minY, maxX, maxY;//生成範囲

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
            //timeがresetを超えた時
            if (Time > reset)
            {
                reset = 0;
                //ランダム種類と位置を決める
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
