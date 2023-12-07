using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondClick : MonoBehaviour
{
    bool isClicked;
    public GameObject myFirstPanel;

    public void Close()
    {
        //When the button this script is attached to is clicked for the first time, it sets the panel active
        isClicked = !isClicked;

        if(isClicked == true)
        {
            myFirstPanel.SetActive(true);
        }

        //When the button this script is attached to is clicked for the second time, it sets the panel false
        if(isClicked == false)
        {
            myFirstPanel.SetActive(false);
        }

    }
}
