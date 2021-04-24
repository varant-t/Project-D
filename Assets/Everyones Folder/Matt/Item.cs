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
            transform.position = holdObject.position;
            transform.parent = holdObject;
            playerItemScript.SetHasItem(true);
        }
    }
}
