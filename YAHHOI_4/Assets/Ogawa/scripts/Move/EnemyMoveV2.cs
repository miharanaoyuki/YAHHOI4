using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveV2 : MonoBehaviour
{
    public float move;
    bool MoveFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        move = move / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveFlag)
        {
            transform.position += new Vector3(move, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MoveFlag = true;
        }
    }
}
