using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemDisplayText : MonoBehaviour
{
    private TextMeshProUGUI itemText;
    [SerializeField] private string textToDisplay;
    private GameObject player;
    private bool enable = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        itemText = GameObject.FindGameObjectWithTag("ItemText").GetComponent<TextMeshProUGUI>();
        itemText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 5 && enable)
        {
            itemText.enabled = true;
            if (textToDisplay != null)
            {
                itemText.text = textToDisplay;
            }
        }
        else
        {
            itemText.enabled = false;
        }

    }
    private void OnMouseExit()
    {
        itemText.enabled = false;
    }
    public void SetEnabled(bool pEnable)
    {
        enable = pEnable;
    }
}
