using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    public Animator cameraZoom;
    public float lerpValue;
    public bool doAnimation;

    public Transform head;

    void Update() {
        if (!doAnimation) return;

        float yRot = head.eulerAngles.y;
        //Debug.Log(yRot);

        if (yRot < 0.01f) {
            cameraZoom.SetTrigger("EarZoomTrigger");
            //HIT interactino must be complete then trigger middle ear zoom on last hit
            //cameraZoom.SetTrigger("MiddleEarZoomTrigger");
            doAnimation = false;
        } else {
            lerpValue += Time.deltaTime;
            head.eulerAngles = Vector3.Lerp(head.eulerAngles, Vector3.zero, lerpValue * .1f);
        }

    }

    void OnMouseDown()
    {
        doAnimation = true;
        HeadRotation.zoomedIn = true;
    }
}
