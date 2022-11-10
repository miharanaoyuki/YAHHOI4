using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//追記しておこう

public class retry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Retry()//ここに書いた文字「Retry」が選択画面で表示される
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}