using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HighlightOnMouseOver : MonoBehaviour

{
    
    public Material EarSelected;
    public Material OriginalColor; 

      // Start is called before the first frame update
    void Start()
    {
        OriginalColor = GetComponent<Renderer>().material;
    }
        void OnMouseEnter()
    {
        gameObject.GetComponent<Renderer>().material = EarSelected;
    }
    void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material = OriginalColor;
    }
}
