using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    Animator animGate;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        animGate = GetComponent<Animator>();
    }
    public void OpenGate()
    {
        animGate.SetTrigger("openGate");
        audio.Play();

    }
}
