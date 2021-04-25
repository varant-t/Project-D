using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool openChest = false;
    private GameObject player;
    private ItemDisplayText displayTextScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        displayTextScript = GetComponent<ItemDisplayText>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 5)
        {
            if (Input.GetKeyDown(KeyCode.E) && !openChest)
            {
                openChest = true;
                displayTextScript.SetEnabled(false);
            }
        }
    }
}
