using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_LR1 : MonoBehaviour
{
    public float move;
    public float time;

    private int counter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(move, 0, 0);

        counter++;

        if (counter==time)
        {
            
        }
    }
}
