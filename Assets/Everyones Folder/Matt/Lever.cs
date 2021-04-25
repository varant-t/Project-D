using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private GameObject player;
    private bool openGate = false;
    private ItemDisplayText displayTextScript;
    private Animator leverAnim;
    [SerializeField] private GameObject gateToOpen;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        displayTextScript = GetComponent<ItemDisplayText>();
        leverAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 5)
        {
            if (Input.GetKeyDown(KeyCode.E) && !openGate)
            {
                openGate = true;
                displayTextScript.SetEnabled(false);
                leverAnim.SetTrigger("leverDown");
            }
        }
    }
    public void EventOpenGate()
    {
        gateToOpen.GetComponent<Gate>().OpenGate();
    }
}
