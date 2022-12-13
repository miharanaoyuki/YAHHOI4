using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysSpawn : MonoBehaviour
{
    public GameObject[] enemys;
    private GameObject player;
    Vector2 vec;
    public int sec = 0;
    private int time = 0;

    bool SpawnFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //enemys = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SpawnFlag)
        {
            time++;
            if (sec < time)
            {
                int index = Random.Range(0, enemys.Length);
                int posY = Random.Range(-10, 10);
                vec = enemys[index].transform.position;
                vec.x += player.transform.position.x + 30;
                Instantiate(enemys[index], new Vector2(vec.x, posY), Quaternion.identity);
                time = 0;
            }
        }
        else
        {
            time = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpawnFlag = false;
    }

}
