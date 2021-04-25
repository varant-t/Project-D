using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Transform holdObject;
    private GameObject player;
    private ItemPickup playerItemScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerItemScript = player.GetComponent<ItemPickup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 5)
        {
            if (Input.GetKeyDown(KeyCode.E) && !playerItemScript.GetHasItem())
            {
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
}
