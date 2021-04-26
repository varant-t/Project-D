using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] private GameObject[] pedestals;
    [SerializeField] private int numOfPedestals;
    private int currNum;
    [SerializeField] private bool openDoor = false;
    Animator doorAnim;
    public AudioSource m_MyAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        doorAnim = GetComponent<Animator>();
    }
    public void CheckWinCondition()
    {
        currNum++;
        if (currNum >= numOfPedestals)
        {
            openDoor = true;
            doorAnim.SetTrigger("openDoor");
            m_MyAudioSource.Play();
        }
    }
}
