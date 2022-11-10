using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestPlayer : MonoBehaviour
{

    static Vector3 latestCheckPoint = new Vector3();
    // Vector3�^��Null�ɂȂ�Ȃ��̂ŁA�����l��Vector3.zero 
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // �L�������`�F�b�N�|�C���g������΃v���C���[�̏����ʒu�͂����ɂ���
        if (latestCheckPoint != Vector3.zero)
        {
            transform.position = latestCheckPoint;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // �ȈՈړ�����
        float x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            latestCheckPoint = transform.position; // ���݈ʒu���L��
            Debug.Log("CheckPoint : " + transform.position);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Scene�ēǂݍ���
        }
    }
}