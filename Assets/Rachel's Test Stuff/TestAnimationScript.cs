using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimationScript : MonoBehaviour
{
    int hitList = 0;

    public GameObject eyes, hair, face, skull, earNormalToHema1, earNormalToHema2, earHemaToShrunk, earShrunkToCauli, earCover, earDrum, earDark,
        cartilage, arteryProximal, arteryDistal, blood1, blood2, bloodClot;

    Renderer eyesRen, hairRen, faceRen, earNormalToHema1Ren, earNormalToHema2Ren, earCoverRen, earCanalRen, earDrumRen, earDarkRen, earShrunkToCauliRen,
        cartilageRen, arteryProximalRen, arteryDistalRen, bloodClotRen;

    public Material skullMat1, earMat1, earMat2, skinMat, skinTransparentMat, cartilageMat1, cartilageMat2,
        arteryMat1, arteryMat2, bloodMat, transparentMat, transparentPartMat, darkMat;

    private Color earNormal, earBruised;

    public Texture earTexture;
    public Texture holdingTexture;
    //can earMat2 inherit the alpha properties of earMat1?

    public Animator arteryDistalAnim, earNormalToHemaAnim, earHemaToShrunkAnim, earShrunkToCauliAnim, cartilageAnim;

    public ParticleSystem blood1Part, blood2Part;

    bool fade = false;

    float fadeout = 1.0f;
    float fadein = 0.0f;

    public float fadeSpeed = 1.0f;


    private void Awake()
    {
        eyesRen = eyes.GetComponent<Renderer>();
        hairRen = hair.GetComponent<Renderer>();
        faceRen = face.GetComponent<Renderer>();
        earNormalToHema1Ren = earNormalToHema1.GetComponent<Renderer>();
        earNormalToHema2Ren = earNormalToHema2.GetComponent<Renderer>();
        earShrunkToCauliRen = earShrunkToCauli.GetComponent<Renderer>();
        earCoverRen = earCover.GetComponent<Renderer>();
        earDrumRen = earDrum.GetComponent<Renderer>();
        earDarkRen = earDark.GetComponent<Renderer>();
        cartilageRen = cartilage.GetComponent<Renderer>();
        arteryProximalRen = arteryProximal.GetComponent<Renderer>();
        arteryDistalRen = arteryDistal.GetComponent<Renderer>();
        bloodClotRen = bloodClot.GetComponent<Renderer>();

        earNormal = earNormalToHema1Ren.material.color;
        earBruised = earNormalToHema2Ren.material.color;
        earBruised.a = 0.0f;
        earNormalToHema2Ren.material.color = earBruised;
    }

    void Update()
    {
        Fade(earNormalToHema1Ren, earNormal, earNormalToHema2Ren, earBruised);
        //Fade();

        /*if (fade)
        {
            if (fadeout > 0.0f)
            {
                Color temp = new Color(earNormal.r, earNormal.g, earNormal.b, fadeout);
                earNormalToHema1Ren.material.color = temp;
                fadeout = temp.a - (fadeSpeed * Time.deltaTime);
            }

            if (fadein < 1.0f)
            {
                Color temp = new Color(earBruised.r, earBruised.g, earBruised.b, fadein);
                earNormalToHema2Ren.material.color = temp;
                fadein = temp.a + (fadeSpeed * Time.deltaTime);
            }
        }*/
    }

    // Start is called before the first frame update
    void Start()
    {
        //set everything to initial state
        //earRen.material = earMat1;
        //skullRen.material = skullMat1;
        //arteryRen.material = arteryMat1;

    }

    void Fade(Renderer ren1, Color color1, Renderer ren2, Color color2)
    {
        if (fade)
        {
            if (fadeout > 0.0f)
            {
                Color temp = new Color(color1.r, color1.g, color1.b, fadeout);
                ren1.material.color = temp;
                fadeout = temp.a - (fadeSpeed * Time.deltaTime);
            }

            if (fadein < 1.0f)
            {
                Color temp = new Color(color2.r, color2.g, color2.b, fadein);
                ren2.material.color = temp;
                fadein = temp.a + (fadeSpeed * Time.deltaTime);
            }
            else
            {
                fade = false;
            }
        }
    }





    public void EarAnim1()
    //first zoom in, adjust material transparency
    {
        Debug.Log("case 0: zoom, adjust transparency");
        StartCoroutine(CrossfadeMaterial(1.0f, faceRen, skinTransparentMat, skinMat));  //fade in face
        StartCoroutine(CrossfadeMaterial(1.0f, eyesRen, eyesRen.material, transparentMat));  //fade out eyes
        StartCoroutine(CrossfadeMaterial(1.0f, hairRen, hairRen.material, transparentMat));  //fade out hair
        StartCoroutine(CrossfadeMaterial(1.0f, arteryProximalRen, arteryMat1, transparentMat));  //fade out proximal artery
        StartCoroutine(CrossfadeMaterial(1.0f, arteryDistalRen, arteryMat1, transparentMat));  //fade out distal artery
        StartCoroutine(CrossfadeMaterial(1.0f, cartilageRen, cartilageMat1, transparentMat));  //fade out cartilage
        StartCoroutine(CrossfadeMaterial(1.0f, earNormalToHema1Ren, skinTransparentMat, skinMat));  //fade in ear
        StartCoroutine(CrossfadeMaterial(1.0f, earCoverRen, skinTransparentMat, skinMat));  //fade in ear cover
    }

    public void EarAnim2()
    //ear bruises
    {
        Debug.Log("case 1: ear bruises");
        skull.SetActive(false);  //turn off skull
                                 //earMat1 = earNormalToHemaRen.materials[0];
                                 //earMat2 = earNormalToHemaRen.materials[1];
                                 //StartCoroutine(CrossfadeAlpha(1.0f, earNormalToHemaRen, earMat1, earMat2));
        fade = true;
        //StartCoroutine(CrossfadeMaterial(1.0f, earNormalToHemaRen, earMat1, earMat2));
        //StartCoroutine(CrossfadeTexture(1.0f earNormalToHemaRen, earMat1, earMat2));  //fade to bruised ear material              
        //BRUISED EAR MATERIAL NOT WORKING
    }

    public void EarAnim3()
    //artery breaks, blood starts flowing
    {
        Debug.Log("case 2: artery breaks, blood flows");
        StartCoroutine(CrossfadeMaterial(1.0f, faceRen, faceRen.material, skinTransparentMat));  //switch to transparent face
        StartCoroutine(CrossfadeMaterial(1.0f, earNormalToHema2Ren, earNormalToHema2Ren.material, skinTransparentMat));  //switch to transparent ear
        StartCoroutine(CrossfadeMaterial(1.0f, earCoverRen, earCoverRen.material, skinTransparentMat));  //switch to transparent ear cover
        StartCoroutine(CrossfadeMaterial(1.0f, arteryProximalRen, arteryProximalRen.material, arteryMat1));  //fade in proximal artery
        StartCoroutine(CrossfadeMaterial(1.0f, arteryDistalRen, arteryDistalRen.material, arteryMat1));  //fade in distal artery
        StartCoroutine(CrossfadeMaterial(1.0f, cartilageRen, cartilageRen.material, cartilageMat1));  //fade in cartilage
        arteryDistalAnim.SetTrigger("play_artery_break");  //play artery break animation
        blood1.SetActive(true);  //turn on flowing blood
        StartCoroutine(CrossfadeMaterial(5.0f, arteryDistalRen, arteryMat1, arteryMat2));  //fade to dark artery material
    }

    public void EarAnim4()
    //hematoma forms
    {
        Debug.Log("case 3: hematoma forms");
        StartCoroutine(CrossfadeMaterial(5.0f, blood1.GetComponent<Renderer>(), bloodMat, transparentPartMat));  //fade out flowing blood  
        blood2.SetActive(false); //turn off flowing blood
        StartCoroutine(CrossfadeMaterial(5.0f, blood2.GetComponent<Renderer>(), transparentPartMat, bloodMat));  //fade in floating blood
        blood2.SetActive(true);  //turn on floating blood
        earNormalToHemaAnim.SetTrigger("play_hematoma");  //play hematoma animaion
    }

    public void EarAnim5()
    //blood clots
    {
        Debug.Log("case 4: blood clots, blood fades");
        StartCoroutine(CrossfadeMaterial(3.0f, blood2.GetComponent<Renderer>(), bloodMat, transparentPartMat));  //fade out floating blood
        bloodClot.SetActive(true);  //turn on blood clot
        StartCoroutine(CrossfadeMaterial(3.0f, bloodClotRen, transparentMat, arteryMat2));  //fade in blood clot
        StartCoroutine(CrossfadeMaterial(3.0f, arteryDistalRen, arteryDistalRen.material, transparentMat));  //fade out distal artery
    }

    public void EarAnim6()
    //cartilage shrinks and changes color, ear shrinks
    {
        Debug.Log("case 5: cartilage/ear shrinks and turns dark");
        earNormalToHema2.SetActive(false);
        earHemaToShrunk.SetActive(true);
        cartilageAnim.SetTrigger("play_shrink_cartilage");
        earHemaToShrunkAnim.SetTrigger("play_hema_to_shrunk");
        StartCoroutine(CrossfadeMaterial(10.0f, bloodClotRen, bloodClotRen.material, transparentMat));  //fade out blood clot                                                                                             //fade bruise texture on outer ear
    }

    public void EarAnim7()
    //cauliflower ear develops
    {
        Debug.Log("case 6: cauliflower ear develops");
        earHemaToShrunk.SetActive(false);
        earShrunkToCauli.SetActive(true);
        arteryProximal.SetActive(false);
        StartCoroutine(CrossfadeMaterial(5.0f, earShrunkToCauliRen, earShrunkToCauliRen.material, skinMat));
        StartCoroutine(CrossfadeMaterial(5.0f, faceRen, faceRen.material, skinMat));
        StartCoroutine(CrossfadeMaterial(5.0f, earCoverRen, earCoverRen.material, skinMat));
        earShrunkToCauliAnim.SetTrigger("play_shrunk_to_cauli");  //play cauliflower ear animation
        //fade in ear texture
        bloodClot.SetActive(false);
    }

    public void EarAnim8()
    //ear drum rips
    {
        Debug.Log("case 7: transition to eardrum rips");
        StartCoroutine(CrossfadeMaterial(5.0f, earCoverRen, earCoverRen.material, transparentMat));
        StartCoroutine(CrossfadeMaterial(5.0f, earCanalRen, earCanalRen.material, skinMat));
        StartCoroutine(CrossfadeMaterial(5.0f, earDrumRen, earDrumRen.material, skinMat));
        StartCoroutine(CrossfadeMaterial(5.0f, earDarkRen, earDarkRen.material, darkMat));
    }
        
       
    private IEnumerator CrossfadeMaterial(float duration, Renderer ren, Material mat1, Material mat2)
    //fades one material into another over a defined duration of time
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {

            elapsedTime += Time.deltaTime;
            ren.material.Lerp(mat1, mat2, elapsedTime / duration);
            yield return null;
        }

    }

}

    //private IEnumerator CrossfadeTexture(float duration, Renderer ren, Material mat1, Material mat2)
    //fades one material into another over a defined duration of time
    //{
       /* float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            dummyMat = new Material(Shader.Find("Standard"));
            
            ren.material.SetTexture("_MainTex", holdingTexture);
            dummyMat.mainTexture = earTexture;
           

     earNormalToHemaRen.material.Lerp(ren.material, dummyMat, elapsedTime / duration);
          

           
            
        }*/
        //yield return null;
    //}
/*
private IEnumerator CrossfadeAlpha(float duration, Renderer ren, Material mat1, Material mat2)
    //fades one material into another over a defined duration of time
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            ren.materials[0].color = Color.green;//mat1.color.a*(1-elapsedTime);
          

           
            
        }
        yield return null;
    }*/

    //https://stackoverflow.com/questions/64510141/using-a-coroutine-in-unity3d-to-fade-a-game-object-out-and-back-in-looping-inf


