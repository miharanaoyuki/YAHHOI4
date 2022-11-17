using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_UD : MonoBehaviour
{
    public float move;
    public float time;//Šî–{1000

    private int counter;

    private void Start()
    {
        move = move / 100;
    }

    private void Update()
    {
        transform.position += new Vector3(0, move, 0);

        counter++;

        if(counter==time)
        {
            counter = 0;
            move *= -1;
        }
    }
}
