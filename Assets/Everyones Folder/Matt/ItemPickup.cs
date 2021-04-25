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
        //Debug.Log(allowDropping);
        if (hasItem)
        {
            heldObject = holdObject.transform.Find(GameObject.FindGameObjectWithTag("Item").transform.name).gameObject;
        }
        if(hasItem && Input.GetKeyDown(KeyCode.Q) && transform.GetComponent<PlayerMovement>().IsGrounded() && allowDropping)
        {
            //Debug.Log("Drop Item");
            playerAnim.SetTrigger("dropItem");
            holdObject.transform.Find("Item").GetComponent<Item>().CollisionOff(false);
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
        Transform item = holdObject.transform.Find(GameObject.FindGameObjectWithTag("Item").transform.name);
        //Transform item = holdObject.transform.Find("Item");
        item.transform.position = itemDestination;
        item.parent = null;
        item.localScale = new Vector3(.25f, .25f, .25f);
    }
    //For placing items on pedestal
    public void PlaceItem(Transform itemDestination)
    {
        //Transform item = holdObject.transform.Find("Item");
        Transform item = holdObject.transform.Find(GameObject.FindGameObjectWithTag("Item").transform.name);
        item.transform.position = itemDestination.position;
        item.parent = null;
        item.localScale = new Vector3(.25f, .25f, .25f);
    }
    public void PickupItem()
    {
        allowPickup = true;
        holdObject.transform.Find(GameObject.FindGameObjectWithTag("Item").transform.name).GetComponent<Item>().PickupItem();
        Invoke("StopPickupItem", 0.1f);
        //Debug.Log("PickupItem");
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

    public void DisableItemOnPedestal()
    {
        holdObject.transform.Find(GameObject.FindGameObjectWithTag("Item").transform.name).GetComponent<Item>().SetIsPlaced();
    }
}
