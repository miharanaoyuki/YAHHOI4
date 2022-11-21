//ステージセレクトで使う
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    public int stage_num; // スコア変数
    GameObject obj; //ドア
    private void Start()
    {
        stage_num = PlayerPrefs.GetInt("Stage", 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (stage_num >= 2)
        {
            obj = GameObject.Find("Gate1");
            Destroy(obj);
            obj = GameObject.Find("Gate2");
            Destroy(obj);
        }
        if (stage_num >= 3)
        {
            obj = GameObject.Find("Gate3");
            Destroy(obj);
        }
        if (stage_num >= 4)
        {
            obj = GameObject.Find("Gate4");
            Destroy(obj);
        }
        if (stage_num >= 5)
        {
            obj = GameObject.Find("Gate5");
            Destroy(obj);
        }
        if (stage_num >= 6)
        {
            obj = GameObject.Find("Gate6");
            Destroy(obj);
        }
        if (stage_num >= 7)
        {
            obj = GameObject.Find("Gate7");
            Destroy(obj);
        }
        if (stage_num >= 8)
        {
            obj = GameObject.Find("Gate8");
            Destroy(obj);
        }
        if (stage_num >= 9)
        {
            obj = GameObject.Find("Gate9");
            Destroy(obj);
        }
        if (stage_num >= 10)
        {
            obj = GameObject.Find("Gate10");
            Destroy(obj);
        }
    }
}
