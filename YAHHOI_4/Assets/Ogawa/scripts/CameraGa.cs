using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGa : MonoBehaviour
{
    private bool isInsideCamera;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�@�J��������O�ꂽ
    private void OnBecameInvisible()
    {
        isInsideCamera = false;
    }
    //�@�J�������ɓ�����
    private void OnBecameVisible()
    {
        isInsideCamera = true;
    }
}
