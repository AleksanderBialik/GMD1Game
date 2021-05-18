using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerSounds : MonoBehaviour
{

    public AudioMixer audioMixer;
    private AudioSource source;
    private CharacterController controller;
    private PlayerMovement player;
    [SerializeField]public AudioClip[] runStoneClips;
    [SerializeField]public AudioClip[] runGroundClips;
    [SerializeField] public AudioClip[] jumpClips;
    [SerializeField] public AudioClip dropClip;

    [SerializeField] public float runningVolume;
    [SerializeField] public float jumpVolume;
    [SerializeField] public float dropVolume;

    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        source = GetComponent<AudioSource>();
        player = GetComponent<PlayerMovement>();
    }

    private void Step()
    {
        if (controller.isGrounded)
        {
            AudioClip runningClip = GetRandomRunClip();
            source.PlayOneShot(runningClip, runningVolume);
        }
        
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
        if (player.surface == "Slope")
        {
            return runStoneClips[UnityEngine.Random.Range(0, runStoneClips.Length)];
        }
        else
        {
            return runGroundClips[UnityEngine.Random.Range(0, runGroundClips.Length)];
        }

    }
    private AudioClip GetRandomJumpClip()
    {
        return jumpClips[UnityEngine.Random.Range(0, jumpClips.Length)];
    }

}
