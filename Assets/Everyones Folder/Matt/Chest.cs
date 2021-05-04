using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private bool openChest = false;
    private GameObject player;
    private ItemDisplayText displayTextScript;
    private Animator animChest;
    public AudioSource m_MyAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        displayTextScript = GetComponent<ItemDisplayText>();
        animChest = GetComponent<Animator>();
    }

    private void OnMouseOver()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 5)
        {
            if (Input.GetKeyDown(KeyCode.E) && !openChest)
            {
                openChest = true;
                displayTextScript.SetEnabled(false);
                animChest.SetTrigger("openChest");
                m_MyAudioSource.Play();
            }
        }
    }
}
