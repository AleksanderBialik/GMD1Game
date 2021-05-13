﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{

    private AudioSource source;
    [SerializeField]public AudioClip[] runClips;
    [SerializeField] public AudioClip[] jumpClips;
    [SerializeField] public AudioClip dropClip;

    [SerializeField] public float runningVolume;
    [SerializeField] public float jumpVolume;
    [SerializeField] public float dropVolume;

    // Start is called before the first frame update
    void Awake()
    {
        
        source = GetComponent<AudioSource>();
    }

    private void Step()
    {
        AudioClip runningClip = GetRandomRunClip();
        source.PlayOneShot(runningClip, runningVolume);
    }

    private void Jump()
    {
        AudioClip jumpingClip = GetRandomJumpClip();
        source.PlayOneShot(jumpingClip,jumpVolume);
    }

    private void Drop()
    {
        source.PlayOneShot(dropClip,dropVolume);
    }

    private AudioClip GetRandomRunClip()
    {
        return runClips[UnityEngine.Random.Range(0, runClips.Length)];
    }
    private AudioClip GetRandomJumpClip()
    {
        return jumpClips[UnityEngine.Random.Range(0, jumpClips.Length)];
    }

}
