﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptItem : MonoBehaviour
{
    [SerializeField] private GameObject itemToAccept;
    private GameObject player;
    private ItemPickup playerItemScript;
    [SerializeField] private Transform itemPlace;
    [SerializeField] private bool itemAccepted = false;

    private ItemDisplayText displayTextScript;
    [SerializeField] private DoorManager doorManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerItemScript = player.GetComponent<ItemPickup>();

        displayTextScript = GetComponent<ItemDisplayText>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < 5)
        {
            if(playerItemScript.GetHasItem() == false || itemAccepted)
            {
                displayTextScript.SetEnabled(false);
            }
            else
            {
                displayTextScript.SetEnabled(true);
                playerItemScript.AllowDroppingItems(false);
                if (playerItemScript.GetHeldObject().CompareTag("Item") && Input.GetKeyDown(KeyCode.Q))
                {
                    playerItemScript.DisableItemOnPedestal();
                    playerItemScript.GetItemPlace(itemPlace);
                    playerItemScript.TriggerAnimPlace();
                    itemAccepted = true;
                    if(doorManagerScript != null)
                    {
                        doorManagerScript.CheckWinCondition();
                    }
                    else
                    {
                        Debug.Log(gameObject.name + " is missing door reference");
                    }

                }
            }

        }

    }
    private void OnMouseExit()
    {
        playerItemScript.AllowDroppingItems(true);
    }
}
