using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Item : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemText;
    [SerializeField] private Transform holdObject;
    private ItemPickup playerItemScript;
    [SerializeField] private Rigidbody itemRB;
    // Start is called before the first frame update
    void Start()
    {
        itemText.enabled = false;
        playerItemScript = GameObject.FindGameObjectWithTag("Player").GetComponent<ItemPickup>();
        itemRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        itemText.enabled = true;
        if (Input.GetKeyDown(KeyCode.E) && !playerItemScript.GetHasItem())
        {
            transform.position = holdObject.position;
            transform.parent = holdObject;
            playerItemScript.SetHasItem(true);
        }
    }
    private void OnMouseExit()
    {
        itemText.enabled = false;
    }
}
