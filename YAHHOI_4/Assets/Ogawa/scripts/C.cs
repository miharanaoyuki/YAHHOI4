using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class C : MonoBehaviour
{
    public string sceneName;//�V�[����inspector�Ŏw��

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("b");
    }
}
