using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint : MonoBehaviour
{
    private GameObject playerObj;//プレイヤーオブジェクト
    public GameObject OutObj;//ワープ先

    bool check = false;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        OutObj = GameObject.FindGameObjectWithTag("Out");
    }

    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            playerObj.transform.position = OutObj.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            check = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //移動時に離れるから
        check = false;
    }
}
