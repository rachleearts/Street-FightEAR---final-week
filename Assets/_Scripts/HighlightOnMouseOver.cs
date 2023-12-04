using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HighlightOnMouseOver : MonoBehaviour

{
    
    public Material EarSelected;
    public Material OriginalColor;
    public GameObject ear;
    public Animator flickerAnimation;

    Renderer rend;

    float duration = 1f;
    bool isFlicker;

      // Start is called before the first frame update
    void Start()
    {
        //OriginalColor = GetComponent<Renderer>().material;
        rend = ear.GetComponent<Renderer>();
        
        StartCoroutine("HighlightFlicker");
    }
        void OnMouseEnter()
    {
        isFlicker = false;
        flickerAnimation.SetBool("FlashOn",false);
        gameObject.GetComponent<Renderer>().material = EarSelected;
    }
    void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material = OriginalColor;
    }

    private void Update()
    {
        if (isFlicker)
        {
         flickerAnimation.SetBool("FlashOn",true);
        }
    }


    IEnumerator HighlightFlicker()
    {
        yield return new WaitForSeconds(5.0f);
        isFlicker = true;
    }

}
