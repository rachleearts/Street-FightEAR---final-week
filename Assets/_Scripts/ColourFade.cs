using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourFade : MonoBehaviour
{

    //public Renderer ourSkullRen;
    public Renderer ourSkull;
    public Color initialColor;
    public Color targetColor;

    float duration = 10.0f;
    
    

    void Start()
    {
        ourSkull = ourSkull.GetComponent<Renderer>();
        
    }
    

     void OnMouseDown()
    {
        StartCoroutine(Fade());
    }

       IEnumerator Fade()
        {
            Color skullColor = ourSkull.material.color;
            for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
            {
                skullColor.a = alpha;
                ourSkull.material.color = skullColor;
                yield return new WaitForSeconds(3f);
            } 
                    
        /*     float elapsedTime = 0f;
            float duration = 3.0f;
           
            ourSkullRen = ourSkull.GetComponent<Renderer>();

            while (elapsedTime < duration)
                {
                    Debug.Log("coroutine");
                    elapsedTime += Time.deltaTime;
                    ourSkullRen.material.color = Color.Lerp(initialColor, targetColor, elapsedTime/duration);
                    yield return null;
                } */

              /*   for (float t=0.01f; t<duration; t+=0.1f)
                {
                    ourSkullRen.material.color = Color.Lerp (initialColor, targetColor, t/duration);
                    yield return null;
                }
                */
            
        }
}

