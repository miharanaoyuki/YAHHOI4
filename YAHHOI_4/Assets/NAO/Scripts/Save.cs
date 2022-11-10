using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestPlayer : MonoBehaviour
{

    static Vector3 latestCheckPoint = new Vector3();
    // Vector3型はNullにならないので、初期値はVector3.zero 
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // 記憶したチェックポイントがあればプレイヤーの初期位置はそこにする
        if (latestCheckPoint != Vector3.zero)
        {
            transform.position = latestCheckPoint;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 簡易移動処理
        float x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            latestCheckPoint = transform.position; // 現在位置を記憶
            Debug.Log("CheckPoint : " + transform.position);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Scene再読み込み
        }
    }
}