using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptItem : MonoBehaviour
{
    [SerializeField] private GameObject itemToAccept;
    private ItemPickup playerItemScript;
    [SerializeField] private Transform itemPlace;
    [SerializeField] private bool itemAccepted = false;
    // Start is called before the first frame update
    void Start()
    {
        playerItemScript = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemPickup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        playerItemScript.AllowDroppingItems(false);
        if (playerItemScript.GetHeldObject().CompareTag("Item") && Input.GetKeyDown(KeyCode.Q))
        {
            playerItemScript.PlaceItem(itemPlace);
            playerItemScript.SetHasItem(false);
            itemAccepted = true;
        }
    }
    private void OnMouseExit()
    {
        playerItemScript.AllowDroppingItems(true);
    }
}
