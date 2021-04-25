using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private bool hasItem = false;
    [SerializeField] private GameObject holdObject;
    private GameObject heldObject;
    private Item heldItemScript;
    //If pedestal is moused over / correct item will not drop item
    private bool allowDropping = true;
    private bool allowPickup = false;
    Animator playerAnim;
    private Transform itemPlace;
    [SerializeField] private Transform itemDrop;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(allowDropping);
        if (hasItem)
        {
            heldObject = holdObject.transform.Find("Item").gameObject;
        }
        if(hasItem && Input.GetKeyDown(KeyCode.Q) && transform.GetComponent<PlayerMovement>().IsGrounded() && allowDropping)
        {
            Debug.Log("Drop Item");
            playerAnim.SetTrigger("dropItem");
        }
    }
    public void SetHasItem(bool carryingItem)
    {
        hasItem = carryingItem;
    }
    public bool GetHasItem()
    {
        return hasItem;
    }
    public GameObject GetHeldObject()
    {
        return heldObject;
    }
    public void AllowDroppingItems(bool allow)
    {
        allowDropping = allow;
    }
    //For placing items on ground
    public void PlaceItem(Vector3 itemDestination)
    {
        holdObject.transform.Find("Item").transform.position = itemDestination;
        holdObject.transform.Find("Item").parent = null;
    }
    //For placing items on pedestal
    public void PlaceItem(Transform itemDestination)
    {
        holdObject.transform.Find("Item").transform.position = itemDestination.position;
        holdObject.transform.Find("Item").parent = null;
    }
    public void PickupItem()
    {
        allowPickup = true;
        holdObject.transform.Find("Item").GetComponent<Item>().PickupItem();
        Invoke("StopPickupItem", 0.1f);
        Debug.Log("PickupItem");
    }
    private void StopPickupItem()
    {
        allowPickup = false;
    }

    public void GrabItem()
    {
        playerAnim.SetTrigger("grabItem");
    }

    public void EventDropItem()
    {
        //PlaceItem(transform.forward * 5);
        //PlaceItem(new Vector3(0, .6f, 0));
        PlaceItem(itemDrop.position);
        hasItem = false;
    }
    public void EventPlaceItem()
    {
        PlaceItem(itemPlace);
        hasItem = false;
    }

    public void GetItemPlace(Transform item)
    {
        itemPlace = item;
    }
    public void TriggerAnimPlace()
    {
        playerAnim.SetTrigger("placeItem");
    }
}
