using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedChest : MonoBehaviour
{
    [SerializeField] private bool openChest = false;
    private GameObject player;
    private ItemDisplayText displayTextScript;
    private Animator animChest;
    private ItemPickup playerItemScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        displayTextScript = GetComponent<ItemDisplayText>();
        animChest = GetComponent<Animator>();
        playerItemScript = player.GetComponent<ItemPickup>();
    }

    private void OnMouseOver()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 5)
        {
            if (playerItemScript.GetHeldObject().CompareTag("Key"))
            {
                displayTextScript.SetText("Press E to unlock");
            }
            if (Input.GetKeyDown(KeyCode.E) && !openChest && playerItemScript.GetHeldObject().CompareTag("Key"))
            {
                openChest = true;
                displayTextScript.SetEnabled(false);
                animChest.SetTrigger("openChest");
            }
        }
    }
}
