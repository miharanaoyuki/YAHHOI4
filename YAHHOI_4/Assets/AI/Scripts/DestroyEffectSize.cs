using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffectSize : MonoBehaviour
{
    public GameObject effect;
    private GameObject[] enemy;
    int Lists;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        Lists = enemy.Length;
        effect.transform.localScale = enemy[Lists].gameObject.transform.localScale;
    }
}
