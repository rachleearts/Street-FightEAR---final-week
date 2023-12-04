using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EardrumSceneController : MonoBehaviour
{
    public GameObject fadeToBlack;

    public Material transparentMat;

    public Animator eardrumRipAnim;

    public AudioSource eardrumRipSound;

    Renderer fadeToBlackRen;

	private void Awake()
	{
        fadeToBlackRen = fadeToBlack.GetComponent<Renderer>();
	}

    public void PlayEardrumTear()
    {
        eardrumRipAnim.SetTrigger("play_eardrum_tear");
        eardrumRipSound.Play();

    }

	void Start()
	{
        StartCoroutine(CrossfadeMaterial(5.0f, fadeToBlackRen, fadeToBlackRen.material, transparentMat));
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
