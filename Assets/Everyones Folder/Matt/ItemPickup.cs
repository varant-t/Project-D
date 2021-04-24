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
    // Start is called before the first frame update
    void Start()
    {
        
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
            PlaceItem(new Vector3(0, -1.4f, 0));
            hasItem = false;
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
    public void PlaceItem(Vector3 itemDestination)
    {
        holdObject.transform.Find("Item").transform.localPosition = itemDestination;
        holdObject.transform.Find("Item").parent = null;
    }
    public void PlaceItem(Transform itemDestination)
    {
        holdObject.transform.Find("Item").transform.position = itemDestination.position;
        holdObject.transform.Find("Item").parent = null;
    }
}
