using UnityEngine;
using System.Collections;

public class MoveFloorA : MonoBehaviour
{

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(initialPosition.x, Mathf.Sin(Time.time) * 3.0f + initialPosition.y, initialPosition.z);
    }
}