using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorScript : MonoBehaviour
{
    public Texture2D myGlove;

        //When the mouse goes over the object the script is attached to, it changes texture (to boxing glove)
        private void OnMouseEnter()
        {
                Cursor.SetCursor(myGlove, Vector2.zero, CursorMode.Auto);
	}


        //When the mouse is no longer over the object the script is attached to, it changed to the default cursor
	private void OnMouseExit()
	{
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}
}
