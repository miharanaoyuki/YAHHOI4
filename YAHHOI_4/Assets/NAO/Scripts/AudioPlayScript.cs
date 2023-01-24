using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayScript : MonoBehaviour
{
    public GameObject audioObject;

    public void AudioPlay()
    {
        audioObject.GetComponent<AudioSource>().Play();
    }
}