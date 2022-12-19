using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDelete : MonoBehaviour
{
    public GameObject Gate;//delete1:bad
    bool keyFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        //Žæ“¾
        Gate = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Gate = GameObject.FindGameObjectWithTag("EditorOnly");
        if (!keyFlag)
        {
            Destroy(Gate);
            //Gate1.SetActive(false);
            Debug.Log("Gate to Open");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            keyFlag = false;
        }
    }

}
