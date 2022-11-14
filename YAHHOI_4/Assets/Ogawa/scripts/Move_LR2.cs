using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_LR2 : MonoBehaviour
{
    public float move;
    public float time;

    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        move = move / 100;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(move * 2, -move * 1.5f, 0);

        counter++;

        if (counter == time)
        {

        }
    }
}
