using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Transform holdObject;
    private GameObject player;
    private ItemPickup playerItemScript;
    private bool isPlaced = false;
    private ItemDisplayText displayTextScript;
    private Rigidbody itemRB;
    [SerializeField] private BoxCollider itemCol;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerItemScript = player.GetComponent<ItemPickup>();
        displayTextScript = GetComponent<ItemDisplayText>();
        itemRB = GetComponent<Rigidbody>();
        itemCol = GetComponent<BoxCollider>();
        holdObject = GameObject.FindGameObjectWithTag("HoldObject").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 5 && !isPlaced)
        {
            if (Input.GetKeyDown(KeyCode.E) && !playerItemScript.GetHasItem())
            {
                CollisionOff(true);
                playerItemScript.GrabItem();
                transform.parent = holdObject;
            }
        }
    }
    public void PickupItem()
    {
        transform.position = holdObject.position;
        playerItemScript.SetHasItem(true);
    }
    //When placed on pedestal should no longer be able to pickup
    public void SetIsPlaced()
    {
        isPlaced = true;
        displayTextScript.SetEnabled(false);
    }
    public void CollisionOff(bool on)
    {
        itemRB.isKinematic = on;
        itemCol.isTrigger = on;
        Debug.Log("Collision " + on);
    }
}
