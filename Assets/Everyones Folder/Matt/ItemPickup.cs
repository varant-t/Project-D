using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private bool hasItem = false;
    [SerializeField] private GameObject holdObject;
    private Item heldItemScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hasItem && Input.GetKeyDown(KeyCode.Q) && transform.GetComponent<PlayerMovement>().IsGrounded())
        {
            Debug.Log("Drop Item");
            holdObject.transform.Find("Item").transform.localPosition = new Vector3(0, -1.4f, 0);
            holdObject.transform.Find("Item").parent = null;
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
}
