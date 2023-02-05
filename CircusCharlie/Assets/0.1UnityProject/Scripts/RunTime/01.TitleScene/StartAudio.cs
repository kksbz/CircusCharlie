using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudio : MonoBehaviour
{
    public AudioClip gameStartAudio = default;
    private AudioSource startAudio = default;
    // Start is called before the first frame update
    void Start()
    {
        startAudio = gameObject.GetComponent<AudioSource>();
        startAudio.clip = gameStartAudio;
    }
}
