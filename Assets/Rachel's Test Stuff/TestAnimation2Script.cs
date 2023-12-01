using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation2Script : MonoBehaviour
{
    public Renderer earNormalToHemaRen;
    public Renderer earBruiseRen;

    private Color earNormal;
    private Color earBruised;

    bool fade = false;

    float fadeout = 1.0f;
    float fadein = 0.0f;

    public float fadeSpeed = 1.0f;

    void Awake()
    {

        earNormal = earNormalToHemaRen.material.color;

        earBruised = earBruiseRen.material.color;
        earBruised.a = 0.0f;
        earBruiseRen.material.color = earBruised;
    }

    void Update()
    {
        if (fade)
        {
            if (fadeout > 0.0f)
            {
                Color temp = new Color(earNormal.r, earNormal.g, earNormal.b, fadeout);
                earNormalToHemaRen.material.color = temp;
                fadeout = temp.a - (fadeSpeed * Time.deltaTime);
            }

            //if (fadein < 1.0f)
            if (fadein < 1.0f)
            {
                Color temp = new Color(earBruised.r, earBruised.g, earBruised.b, fadein);
                earBruiseRen.material.color = temp;
                fadein = temp.a + (fadeSpeed * Time.deltaTime);
            }
        }
    }

	private void OnMouseDown()
	{
        fade = true;
    }
	

}   
