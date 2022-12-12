using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysSpawn : MonoBehaviour
{
    public GameObject[] enemys;
    Vector2 vec;
    public float y;
    public int sec = 0;
    private int time = 0;

    bool SpawnFlag = true;

    // Start is called before the first frame update
    void Start()
    {

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
                vec.y = gameObject.transform.position.y;
                Instantiate(enemys[index], new Vector2(0, posY), Quaternion.identity);
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
