using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotion : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    public float circle_radius = 1.0f;

    private Vector2 initPosition;

    void Start()
    {
        initPosition = transform.position;
        moveSpeed = moveSpeed / 100;
    }

    private void Update()
    {
        Vector2 pos = transform.position;

        float rad = moveSpeed * Mathf.Rad2Deg * Time.time;

        pos.x = Mathf.Cos(rad) * circle_radius;

        pos.y = Mathf.Sin(rad) * circle_radius;

        transform.position = pos + initPosition;
    }
}
