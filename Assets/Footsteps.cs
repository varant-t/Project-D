using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    [SerializeField]

    private AudioClip[] clips;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void Step()
    {
        AudioClip clip = GetClip();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }

}
