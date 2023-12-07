using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PerforationBtnActive : MonoBehaviour
{
    public GameObject buttonPerf;

    //sets perforation button active at the end of the eardrum tear animation
    void AnimTrigger()
    {
        buttonPerf.SetActive(true);
    }
}
