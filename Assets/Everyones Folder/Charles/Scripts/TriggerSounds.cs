using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSounds : MonoBehaviour
{




    public AudioSource m_audioSource;



    private void awake()
    {
        m_audioSource = GetComponent<AudioSource>();
    }




    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Player"))
        {

            m_audioSource.Play();

            Destroy(gameObject, m_audioSource.clip.length);

        }



    }
}


    