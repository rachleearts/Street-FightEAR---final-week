using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleConfirm : MonoBehaviour
{
    public void ConfirmClick(Button confirmButton) //cannot not select confirm in picture quiz until one toggle is selected
    {
        confirmButton.interactable = true;
    }
}
