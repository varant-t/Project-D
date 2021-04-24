using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Transform holdObject;
    private ItemPickup playerItemScript;
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
        if (Input.GetKeyDown(KeyCode.E) && !playerItemScript.GetHasItem())
        {
            playerItemScript.GrabItem();
            transform.parent = holdObject;
        }
    }
    public void PickupItem()
    {
        transform.position = holdObject.position;
        playerItemScript.SetHasItem(true);
    }
}
