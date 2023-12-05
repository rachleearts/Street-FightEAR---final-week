using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorScript : MonoBehaviour
{
    public Texture2D myGlove;

    // Update is called once per frame

    
    private void OnMouseEnter()
	{
        Debug.Log("mouse enter");
        Cursor.SetCursor(myGlove, Vector2.zero, CursorMode.Auto);
	}

	private void OnMouseExit()
	{
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
	}
}
