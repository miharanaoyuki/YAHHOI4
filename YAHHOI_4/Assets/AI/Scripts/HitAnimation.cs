using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private int effectTime = 0;
    bool HitFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (HitFlag)
        {
            _animator.SetBool("Hit", true);
            HitFlag = false;
        }
        else if(!HitFlag)
        {
            _animator.SetBool("Hit", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HitFlag = true;
        }
        //else
        //{
        //    HitFlag = false;
        //}
    }
}
