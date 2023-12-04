using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HighlightOnMouseOver : MonoBehaviour

    
{   
    public Material material1;
    public Material material2;
    public GameObject ear;
    float duration = 2.0f;
    Renderer rend;
    
    public Material EarSelected;
    public Material OriginalColor; 

    void Start()
    //highlight ear on mouse over
    {
        rend = ear.GetComponent<Renderer> ();
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
    
    void Update()
    {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        rend.material.Lerp(material1, material2, lerp);
    }
}
