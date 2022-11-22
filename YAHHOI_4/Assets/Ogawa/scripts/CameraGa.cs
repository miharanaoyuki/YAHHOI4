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

    //　カメラから外れた
    private void OnBecameInvisible()
    {
        isInsideCamera = false;
    }
    //　カメラ内に入った
    private void OnBecameVisible()
    {
        isInsideCamera = true;
    }
}
