using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCursor : MonoBehaviour
{
    public Texture2D cursorArrow;
   
    private void Start()
    {
        //Cursor.visible = false;
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
