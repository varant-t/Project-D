using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemDisplayText : MonoBehaviour
{
    private TextMeshProUGUI itemText;
    [SerializeField] private string textToDisplay;
    // Start is called before the first frame update
    void Start()
    {
        itemText = GameObject.FindGameObjectWithTag("ItemText").GetComponent<TextMeshProUGUI>();
        itemText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        itemText.enabled = true;
        if (textToDisplay != null)
        {
            itemText.text = textToDisplay;
        }
    }
    private void OnMouseExit()
    {
        itemText.enabled = false;
    }
}
