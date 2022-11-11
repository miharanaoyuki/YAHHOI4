using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public string SceneName;

    public void OnClickStartButton()
    {
        SceneManager.LoadScene(SceneName);
    }

}
