using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    void Start()
    {
        speed = speed / 400;
    }

    void Update()
    {
        Vector2 Position = transform.position;

        //âEÇ…à⁄ìÆ
        if (Input.GetKey(KeyCode.D)||(Input.GetKey(KeyCode.RightArrow)))
        {
            Position.x += speed;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        //ç∂Ç…à⁄ìÆ
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            Position.x -= speed;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow)))
        {
            Position.y += speed;
        }
        if (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow)))
        {
            Position.y -= speed;
        }

        transform.position = Position;
    }
}
