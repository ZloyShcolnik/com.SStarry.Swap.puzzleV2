using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambient : MonoBehaviour
{
    private AudioSource _audioSource;
    
    void Start()
    {

        if (FindObjectsOfType<Ambient>().Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _audioSource.enabled = SoundService.IsMusicOn;
    }
}
