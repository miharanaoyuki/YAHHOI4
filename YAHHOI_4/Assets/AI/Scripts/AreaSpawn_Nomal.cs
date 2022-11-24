using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawn_Nomal : MonoBehaviour
{
    public GameObject[] enemyList;
    private GameObject playerObject;
    private GameObject _mainCamera;
    Vector2 pos;
    float minX, minY, maxX, maxY = 0;
    public int Time = 0;
    private int reset = 0;

    bool SpawnFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!SpawnFlag)
        {
            reset++;
            //reset‚ªtime‚ð’´‚¦‚½Žž
            if (Time < reset)
            {
                reset = 0;
                //ƒ‰ƒ“ƒ_ƒ€Ží—Þ‚ÆˆÊ’u‚ðŒˆ‚ß‚é
                int index = Random.Range(0, enemyList.Length);
                float posX = Random.Range(minX, maxX);
                float posY = Random.Range(minY, maxY);
                pos = enemyList[index].transform.position;
                pos.x += posX;
                pos.y += posY;
                Instantiate(enemyList[index], new Vector2(pos.x, pos.y), Quaternion.identity);
            }
        }
        else
        {
            SpawnFlag = true;
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
